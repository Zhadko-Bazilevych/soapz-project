using Azure.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SOAPZ.Operations.BookInfo;
using SOAPZ.Operations.Books;
using SOAPZ.Operations.MyBooks;
using SOAPZ.Services;
using System.Threading.Tasks.Dataflow;

namespace SOAPZ.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContentController : ControllerBase
    {
        private readonly BookService bookService;

        public ContentController(BookService _bookService)
        {
            bookService = _bookService;
        }

        [AllowAnonymous]
        [HttpPost("Books")]
        public async Task<ActionResult> Books(BooksRequest request)
        {
            return new JsonResult(await bookService.BooksOperation(request));
        }

        [AllowAnonymous]
        [HttpGet("Books/{id:int}")]
        public async Task<ActionResult> Books(int id)
        {
            return new JsonResult(await bookService.BookInfoOperation(id));
        }

        [Authorize]
        [HttpPost("MyBooks")]
        public async Task<ActionResult> MyBooks(MyBooksRequest request)
        {
            return new JsonResult(await bookService.MyBooksOperation(request));
        }

    }
}
