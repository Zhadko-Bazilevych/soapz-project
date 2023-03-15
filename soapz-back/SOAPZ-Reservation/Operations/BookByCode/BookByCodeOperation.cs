using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SOAPZ_Reservation.Common;
using SOAPZ_Reservation.Operations.BookByCode;
using static SOAPZ_Reservation.Operations.BookByCode.BookByCodeResponse;

namespace SOAPZ.Operations.BookByCode
{
    public class BookByCodeOperation
    {
        DataContext db;

        private readonly IMapper _mapper;

        public BookByCodeOperation(DataContext db, IMapper mapper)
        {
            this.db = db;
            this._mapper = mapper;
        }

        public async Task<BookByCodeResponse> Execute(BookByCodeRequest request)
        {
            var validate = await Validate(request);
            if(validate.Code != 200)
            {
                return new BookByCodeResponse { Code = validate.Code, Message = validate.Message };
            }

            var reservResult = (await db.Reservations.Include(y => y.Book).Include(y=>y.Status).Where(x => x.Reservation_code == request.Code).ToArrayAsync()).FirstOrDefault();
            var result = _mapper.Map<ReservationsView>(reservResult);

            return new BookByCodeResponse
            {
                Reservation = result
            };
        }

        public async Task<ValidateResult> Validate(BookByCodeRequest request)
        {
            var checkCode = await db.Reservations.AnyAsync(x => x.Reservation_code == request.Code);
            if (!checkCode)
            {
                return new ValidateResult { Code = 400, Message = "Invalid code" };
            }
            return new ValidateResult();
        }

    }
}
