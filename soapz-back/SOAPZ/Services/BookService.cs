using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using static System.Net.Mime.MediaTypeNames;
using System.Text.Json;
using SOAPZ.Operations.Books;
using SOAPZ.Operations.BookInfo;
using SOAPZ.Operations.MyBooks;

namespace SOAPZ.Services
{
    public class BookService
    {
        private IConfiguration Config;
        private HttpClient _httpClient;

        string BaseRoute,
            BooksEndpoint,
            BookInfoEndpoint,
            MyBooksEndpoint;

        public BookService(HttpClient httpClient, IConfiguration config)
        {
            _httpClient = httpClient;
            Config = config;
            BaseRoute = Config["Services:BookService:BaseUrl"] ?? "";
            BooksEndpoint = Config["Services:BookService:Books"] ?? "";
            BookInfoEndpoint = Config["Services:BookService:BookInfo"] ?? "";
            MyBooksEndpoint = Config["Services:BookService:MyBooks"] ?? "";
        }
        public async Task<BooksResponse> BooksOperation(BooksRequest request)
        {
            var todoItemJson = new StringContent(
            JsonSerializer.Serialize(request),
            Encoding.UTF8,
            Application.Json); // using static System.Net.Mime.MediaTypeNames;

            var httpResponseMessage =
                await _httpClient.PostAsync(BaseRoute + BooksEndpoint, todoItemJson);

            var res = await httpResponseMessage.Content.ReadAsStringAsync();

            int code = (int)httpResponseMessage.StatusCode;
            if (code != 200)
            {
                return new BooksResponse { Code = code, Message = httpResponseMessage.ReasonPhrase };
            }

            return JsonSerializer.Deserialize<BooksResponse>(res, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

        }

        public async Task<BookInfoResponse> BookInfoOperation(int id)
        {
            //var todoItemJson = new StringContent(
            //JsonSerializer.Serialize(request),
            //Encoding.UTF8,
            //Application.Json); // using static System.Net.Mime.MediaTypeNames;

            var httpResponseMessage =
                await _httpClient.GetAsync(BaseRoute + BookInfoEndpoint + id);

            var res = await httpResponseMessage.Content.ReadAsStringAsync();

            int code = (int)httpResponseMessage.StatusCode;
            if (code != 200)
            {
                return new BookInfoResponse { Code = code, Message = httpResponseMessage.ReasonPhrase };
            }

            return JsonSerializer.Deserialize<BookInfoResponse>(res, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

        }

        public async Task<MyBooksResponse> MyBooksOperation(MyBooksRequest request)
        {
            var todoItemJson = new StringContent(
            JsonSerializer.Serialize(request),
            Encoding.UTF8,
            Application.Json); // using static System.Net.Mime.MediaTypeNames;

            var httpResponseMessage =
                await _httpClient.PostAsync(BaseRoute + MyBooksEndpoint, todoItemJson);

            var res = await httpResponseMessage.Content.ReadAsStringAsync();

            int code = (int)httpResponseMessage.StatusCode;
            if (code != 200)
            {
                return new MyBooksResponse { Code = code, Message = httpResponseMessage.ReasonPhrase };
            }

            return JsonSerializer.Deserialize<MyBooksResponse>(res, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

        }

    }
}
