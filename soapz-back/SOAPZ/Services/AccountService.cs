using Microsoft.AspNetCore.Mvc;
using SOAPZ.Operations.Login;
using static System.Net.Mime.MediaTypeNames;
using System.Text.Json;
using System.Text;
using SOAPZ.Operations.Register;

namespace SOAPZ.Services
{
    public class AccountService
    {
        private IConfiguration Config;
        private HttpClient _httpClient;

        string BaseRoute,
            LoginEndpoint,
            RegisterEndpoint;

        public AccountService(HttpClient httpClient, IConfiguration config)
        {
            _httpClient = httpClient;
            Config = config;
            BaseRoute = Config["Services:AccountService:BaseUrl"] ?? "";
            LoginEndpoint = Config["Services:AccountService:Login"] ?? "";
            RegisterEndpoint = Config["Services:AccountService:Register"] ?? "";
        }
        
        public async Task<LoginResponse> LoginOperation(LoginRequest request)
        {
            var todoItemJson = new StringContent(
            JsonSerializer.Serialize(request),
            Encoding.UTF8,
            Application.Json); // using static System.Net.Mime.MediaTypeNames;

            var httpResponseMessage =
                await _httpClient.PostAsync(BaseRoute + LoginEndpoint, todoItemJson);

            var res = await httpResponseMessage.Content.ReadAsStringAsync();

            int code = (int)httpResponseMessage.StatusCode;
            if (code != 200)
            {
                return new LoginResponse { Code = code, Message = httpResponseMessage.ReasonPhrase };
            }

            return JsonSerializer.Deserialize<LoginResponse>(res, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

        }

        public async Task<RegisterResponse> RegisterOperation(RegisterRequest request)
        {
            var todoItemJson = new StringContent(
            JsonSerializer.Serialize(request),
            Encoding.UTF8,
            Application.Json); // using static System.Net.Mime.MediaTypeNames;

            var httpResponseMessage =
                await _httpClient.PostAsync(BaseRoute + RegisterEndpoint, todoItemJson);

            var res = await httpResponseMessage.Content.ReadAsStringAsync();

            int code = (int)httpResponseMessage.StatusCode;
            if (code != 200)
            {
                return new RegisterResponse { Code = code, Message = httpResponseMessage.ReasonPhrase };
            }

            return JsonSerializer.Deserialize<RegisterResponse>(res, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

        }

    }
}
