using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SOAPZ_Book.Common;
using static SOAPZ_Book.Operations.MyBooks.MyBooksResponse;

namespace SOAPZ_Book.Operations.MyBooks
{
    public class MyBooksOperation
    {
        DataContext db;

        private readonly IMapper _mapper;

        public MyBooksOperation(DataContext db, IMapper mapper)
        {
            this.db = db;
            this._mapper = mapper;
        }

        public async Task<MyBooksResponse> Execute(MyBooksRequest request)
        {
            var validate = await Validate(request);
            if(validate.Code != 200)
            {
                return new MyBooksResponse { Code = validate.Code, Message = validate.Message };
            }

            var reservResult = await db.Reservations.Include(y => y.Book).Include(y=>y.Status).Where(x => x.UserId == request.Id).OrderByDescending(o=>o.Id).ToArrayAsync();
            var result = _mapper.Map<ReservationsView[]>(reservResult);

            var userCode = (await db.Users.Where(x => x.Id == request.Id).FirstOrDefaultAsync()).Code;

            return new MyBooksResponse {
                Books = result, 
                UserCode = userCode
            };
        }

        public async Task<ValidateResult> Validate(MyBooksRequest request)
        {
            var checkCode = await db.Users.AnyAsync(x => x.Id == request.Id);
            if (!checkCode)
            {
                return new ValidateResult { Code = 400, Message = "Invalid user" };
            }
            return new ValidateResult();
        }

    }
}
