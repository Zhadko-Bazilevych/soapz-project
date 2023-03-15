using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SOAPZ_Reservation.Common;

namespace SOAPZ_Reservation.Operations.Reservation
{
    public class ReservationOperation
    {
        DataContext db;

        public ReservationOperation(DataContext db)
        {
            this.db = db;
        }

        public async Task<ReservationResponse> Execute(ReservationRequest request)
        {
            var validate = await Validate(request);
            if(validate.Code != 200)
            {
                return new ReservationResponse { Code = validate.Code, Message = validate.Message };
            }

            var reservBook = await db.Books.Where(x => x.Id == request.BookId).FirstOrDefaultAsync();
            if(reservBook.Amount == 0)
            {
                return new ReservationResponse { Code = 409, Message = "Copies of this book are out" };
            }
            reservBook.Amount--;

            Data.Reservation reservation = new Data.Reservation
            {
                BookId = request.BookId,
                UserId = request.UserId,
                Reservation_code = request.ReservationCode,
                Reservation_date = DateTime.Now,
                Expiration_date = DateTime.Now.AddDays(7),
                StatusId = 1
            };
            db.Reservations.Add(reservation);


            await db.SaveChangesAsync();

            return new ReservationResponse();
        }

        public async Task<ValidateResult> Validate(ReservationRequest request)
        {
            var checkBook = await db.Books.AnyAsync(x => x.Id == request.BookId);
            if (!checkBook)
            {
                return new ValidateResult { Code = 204, Message = "Book not found" };
            }
            var checkCode = await db.Reservations.AnyAsync(x => x.Reservation_code == request.ReservationCode);
            if (checkCode)
            {
                return new ValidateResult { Code = 400, Message = "Such reservation code is not unique" };
            }
            return new ValidateResult();
        }
    }
}
