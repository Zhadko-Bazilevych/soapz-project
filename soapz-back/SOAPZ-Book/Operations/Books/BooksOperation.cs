using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SOAPZ_Book.Common;
using static SOAPZ_Book.Operations.Books.BooksResponse;

namespace SOAPZ_Book.Operations.Books
{
    public class BooksOperation
    {
        private readonly IMapper _mapper;

        DataContext db;


        public BooksOperation(DataContext db, IMapper mapper)
        {
            this.db = db;
            this._mapper = mapper;
        }

        public async Task<BooksResponse> Execute(BooksRequest request)
        {
            var validate = await Validate(request);
            if(validate.Code != 200)
            {
                return new BooksResponse { Code = validate.Code, Message = validate.Message };
            }
            
            var booksResult = db.Books.Where(x => x.Title.Contains(request.Title ?? "") &&
                                             x.Pages >= request.PagesMin &&
                                             x.Pages <= request.PagesMax &&
                                             x.YearPublished >= request.YearMin &&
                                             x.YearPublished <= request.YearMax &&
                                             x.Amount > (request.IsPresent??false ? 0 : -1))
                                .Include(y => y.Language)
                                .Include(y => y.Author)
                                .Include(y => y.PublishingHouse)
                                .Where(x => x.Language.Name.Contains(request.Language ?? "") &&
                                            x.Author.FullName.Contains(request.AuthorName ?? "") &&
                                            x.PublishingHouse.Name.Contains(request.Pubisher ?? ""));

            var result = _mapper.Map<BooksView[]>(booksResult);

            return new BooksResponse { 
                Books = result, 
                Count = result.Length,
                Code = (result.Length != 0 ? 200 : 204) 
            };
        }

        public async Task<ValidateResult> Validate(BooksRequest request)
        {
            if (request.YearMin == null)
            {
                request.YearMin = 0;
            }
            if (request.YearMax == null)
            {
                request.YearMax = int.MaxValue;
            }
            if (request.PagesMin == null)
            {
                request.PagesMin = 0;
            }
            if (request.PagesMax == null)
            {
                request.PagesMax = int.MaxValue;
            }
            return new ValidateResult();
        }

    }
}
