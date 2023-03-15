using Microsoft.AspNetCore.Identity;
using SOAPZ_Account.Common;
using SOAPZ_Account.Operations.Logout;
using SOAPZ_Account.Services;

namespace SOAPZ_Account.Operations.Logout
{
    public class LogoutOperation
    {
        DataContext db;
        UserManager<User> userManager;
        TokenService tokenService;

        public LogoutOperation(DataContext db, UserManager<User> userManager, TokenService tokenService)
        {
            this.db = db;
            this.userManager = userManager;
            this.tokenService = tokenService;
        }

        public async Task<LogoutResponse> Execute(LogoutRequest request)
        {
            var validate = await Validate(request);
            if (validate.Code != 200)
            {
                return new LogoutResponse { Code = validate.Code, Message = validate.Message };
            }

            return new LogoutResponse { Message = "Here you need to delete refresh from db" };
        }

        public async Task<ValidateResult> Validate(LogoutRequest request)
        {
            return new ValidateResult();
        }
    }
}
