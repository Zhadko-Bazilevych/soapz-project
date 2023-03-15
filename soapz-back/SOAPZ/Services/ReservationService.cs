using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using static System.Net.Mime.MediaTypeNames;
using System.Text.Json;
using SOAPZ.Operations.Reservation;
using SOAPZ.Operations.StatusUpdate;
using SOAPZ.Operations.BookByCode;

namespace SOAPZ.Services
{
    public class ReservationService
    {
        private IConfiguration Config;
        private HttpClient _httpClient;

        string BaseRoute,
            ReservateEndpoint,
            StatusUpdateEndpoint,
            BookByCodeEndpoint;

        public ReservationService(HttpClient httpClient, IConfiguration config)
        {
            _httpClient = httpClient;
            Config = config;
            BaseRoute = Config["Services:ReservationService:BaseUrl"] ?? "";
            ReservateEndpoint = Config["Services:ReservationService:Reservate"] ?? "";
            StatusUpdateEndpoint = Config["Services:ReservationService:StatusUpdate"] ?? "";
            BookByCodeEndpoint = Config["Services:ReservationService:BookByCode"] ?? "";
        }

        public async Task<ReservationResponse> ReservateOperation(ReservationRequest request)
        {
            var todoItemJson = new StringContent(
            JsonSerializer.Serialize(request),
            Encoding.UTF8,
            Application.Json); // using static System.Net.Mime.MediaTypeNames;

            var httpResponseMessage =
                await _httpClient.PostAsync(BaseRoute + ReservateEndpoint, todoItemJson);

            var res = await httpResponseMessage.Content.ReadAsStringAsync();

            int code = (int)httpResponseMessage.StatusCode;
            if (code != 200)
            {
                return new ReservationResponse { Code = code, Message = httpResponseMessage.ReasonPhrase };
            }

            return JsonSerializer.Deserialize<ReservationResponse>(res, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task<StatusUpdateResponse> StatusUpdateOperation(StatusUpdateRequest request)
        {
            var todoItemJson = new StringContent(
            JsonSerializer.Serialize(request),
            Encoding.UTF8,
            Application.Json); // using static System.Net.Mime.MediaTypeNames;

            var httpResponseMessage =
                await _httpClient.PostAsync(BaseRoute + StatusUpdateEndpoint, todoItemJson);

            var res = await httpResponseMessage.Content.ReadAsStringAsync();

            int code = (int)httpResponseMessage.StatusCode;
            if (code != 200)
            {
                return new StatusUpdateResponse { Code = code, Message = httpResponseMessage.ReasonPhrase };
            }

            return JsonSerializer.Deserialize<StatusUpdateResponse>(res, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task<BookByCodeResponse> BookByCodeOperation(BookByCodeRequest request)
        {
            var todoItemJson = new StringContent(
            JsonSerializer.Serialize(request),
            Encoding.UTF8,
            Application.Json); // using static System.Net.Mime.MediaTypeNames;

            var httpResponseMessage =
                await _httpClient.PostAsync(BaseRoute + BookByCodeEndpoint, todoItemJson);

            var res = await httpResponseMessage.Content.ReadAsStringAsync();

            int code = (int)httpResponseMessage.StatusCode;
            if (code != 200)
            {
                return new BookByCodeResponse { Code = code, Message = httpResponseMessage.ReasonPhrase, };
            }

            return JsonSerializer.Deserialize<BookByCodeResponse>(res, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

    }
}
