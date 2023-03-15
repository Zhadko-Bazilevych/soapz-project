using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SOAPZ_Book.Common;
using SOAPZ_Book.Operations.Books;

namespace SOAPZ_Book.Operations.BookInfo
{
    public class BookInfoOperation
    {
        DataContext db;
        private readonly IMapper _mapper;

        public BookInfoOperation(DataContext db, IMapper mapper)
        {
            this.db = db;
            _mapper = mapper;
        }

        public async Task<BookInfoResponse> Execute(int id)
        {
            var validate = await Validate(id);
            if(validate.Code != 200)
            {
                return new BookInfoResponse { Code = validate.Code, Message = validate.Message };
            }

            var bookresult = await db.Books.Where(x => x.Id == id).Include(y=>y.Author)
                                                              .Include(y=>y.Language)
                                                              .Include(y=>y.PublishingHouse)
                                                              .Include(y=>y.Genres).ThenInclude(y=>y.Genre)
                                                              .FirstOrDefaultAsync();

            var result = _mapper.Map<BookInfo>(bookresult);

            if (result == null)
            {
                return new BookInfoResponse { Code = 404, Message = "No book found" };
            }
            return new BookInfoResponse { Book = result };
        }

        public async Task<ValidateResult> Validate(int id)
        {
            return new ValidateResult();
        }

    }
}
