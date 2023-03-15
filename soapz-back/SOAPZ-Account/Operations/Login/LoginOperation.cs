using Microsoft.AspNetCore.Identity;
using SOAPZ_Account.Common;
using SOAPZ_Account.Data;
using SOAPZ_Account.Operations.Register;
using SOAPZ_Account.Services;

namespace SOAPZ_Account.Operations.Login
{
    public class LoginOperation
    {
        DataContext db;
        UserManager<User> userManager;
        SignInManager<User> signInManager;
        TokenService tokenService;

        public LoginOperation(DataContext db, UserManager<User> userManager, SignInManager<User> signInManager, TokenService tokenService)
        {
            this.db = db;
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.tokenService = tokenService;
        }

        public async Task<LoginResponse> Execute(LoginRequest request)
        {
            var validate = await Validate(request);
            if (validate.Code != 200)
            {
                return new LoginResponse { Code = validate.Code, Message = validate.Message };
            }

            var user = await userManager.FindByEmailAsync(request.Email);
            if (user == null)
            {
                return new LoginResponse { Code = 401, Message = "Invalid credentials" };
            }
            var roles = await userManager.GetRolesAsync(user);

            var result = await signInManager.CheckPasswordSignInAsync(user, request.Password, false);

            if (result.Succeeded)
            {
                var token = tokenService.CreateToken(user);
                return new LoginResponse { Token = token, Id = user.Id, Mail = user.Email, Role = roles.First() };
            }

            return new LoginResponse { Code = 401, Message = "Invalid credentials" };
        }

        public async Task<ValidateResult> Validate(LoginRequest request)
        {
            return new ValidateResult();
        }
    }
}
