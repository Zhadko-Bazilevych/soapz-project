using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SOAPZ_Book.Operations.BookInfo;
using SOAPZ_Book.Operations.Books;
using SOAPZ_Book.Operations.MyBooks;
using System.Threading.Tasks.Dataflow;

namespace SOAPZ_Book.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContentController : ControllerBase
    {
        private readonly IServiceProvider _serviceProvider;

        public ContentController(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        [AllowAnonymous]
        [HttpPost("Books")]
        public async Task<ActionResult> Books(BooksRequest request)
        {
            var operation = _serviceProvider.GetRequiredService<BooksOperation>();
            var result = await operation.Execute(request);
            if (result.Code != 200)
            {
                return StatusCode(result.Code, result.Message);
            }
            return new JsonResult(result);
        }

        [AllowAnonymous]
        [HttpGet("Books/{id:int}")]
        public async Task<ActionResult> Books(int id)
        {
            var operation = _serviceProvider.GetRequiredService<BookInfoOperation>();
            var result = await operation.Execute(id);
            if (result.Code != 200)
            {
                return StatusCode(result.Code, result.Message);
            }
            return new JsonResult(result);
        }

        [AllowAnonymous]
        [HttpPost("MyBooks")]
        public async Task<ActionResult> MyBooks(MyBooksRequest request)
        {
            var operation = _serviceProvider.GetRequiredService<MyBooksOperation>();
            var result = await operation.Execute(request);
            if (result.Code != 200)
            {
                return StatusCode(result.Code, result.Message);
            }
            return new JsonResult(result);
        }

    }
}
