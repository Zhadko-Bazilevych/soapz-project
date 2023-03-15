using SOAPZ_Account.Common;

namespace SOAPZ_Account.Operations.Login
{
    public class LoginResponse : BaseResponse
    {
        public string? Id { get; set; }
        public string? Mail { get; set; }
        public string? Token { get; set; } = null;
        public string? Role { get; set; }

    }
}
