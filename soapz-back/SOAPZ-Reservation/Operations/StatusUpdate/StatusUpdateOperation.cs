using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SOAPZ_Reservation.Common;

namespace SOAPZ_Reservation.Operations.StatusUpdate
{
    public class StatusUpdateOperation
    {
        DataContext db;

        public StatusUpdateOperation(DataContext db)
        {
            this.db = db;
        }

        public async Task<StatusUpdateResponse> Execute(StatusUpdateRequest request)
        {
            try
            {
                var validate = await Validate(request);
                if (validate.Code != 200)
                {
                    return new StatusUpdateResponse { Code = validate.Code, Message = validate.Message };
                }

                var reservation = await db.Reservations.Include("Status").Where(x => x.Reservation_code == request.ReservationCode).FirstOrDefaultAsync();
                if (reservation == null)
                {
                    return new StatusUpdateResponse { Code = 204, Message = "Reservation is missing" };
                }

                int statusId = (await db.Statuses.Where(x => x.Name == request.Status).FirstOrDefaultAsync()).Id;

                reservation.StatusId = statusId;

                if (request.Status == "Taken" || request.Status == "Taken late")
                {
                    reservation.Returning_date = DateTime.Now;
                    var reservBook = await db.Reservations.Include(y => y.Book).Where(x => x.Reservation_code == request.ReservationCode).FirstOrDefaultAsync();
                    reservBook.Book.Amount++;
                }
                if (request.Status == "Given")
                {
                    reservation.Receiving_date = DateTime.Now;
                }

                await db.SaveChangesAsync();

                return new StatusUpdateResponse();
            }
            catch(Exception e)
            {
                return new StatusUpdateResponse();
            }
        }

        public async Task<ValidateResult> Validate(StatusUpdateRequest request)
        {
            var reservation = db.Reservations.Any(x => x.Reservation_code == request.ReservationCode);
            var status = db.Statuses.Any(x => x.Name == request.Status);
            if (!status)
            {
                return new ValidateResult { Code = 204, Message = "Status is missing" };
            }
            if (!reservation)
            {
                return new ValidateResult { Code = 204, Message = "Reservation code is invalid" };
            }

            return new ValidateResult();
        }
    }
}
