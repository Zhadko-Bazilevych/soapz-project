using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SOAPZ_Account.Common;

namespace SOAPZ_Account.Operations.Register
{
    public class RegisterOperation
    {
        DataContext db;
        UserManager<User> userManager;
        public RegisterOperation(DataContext db, UserManager<User> userManager)
        {
            this.db = db;
            this.userManager = userManager;
        }

        public async Task<RegisterResponse> Execute(RegisterRequest request)
        {
            var validate = await Validate(request);
            if(validate.Code != 200)
            {
                return new RegisterResponse { Code = validate.Code, Message = validate.Message};
            }

            var userEmail = await userManager.FindByEmailAsync(request.Email);
            if(userEmail != null)
            {
                return new RegisterResponse { Code = 400, Message = "Such email has already been taken" };
            }
            
            var userPhone = await userManager.Users.Where(x => x.PhoneNumber == request.Phone).SingleOrDefaultAsync();
            if (userPhone != null)
            {
                return new RegisterResponse { Code = 400, Message = "Such phone has already been taken" };
            }

            var newUser = new User
            {
                UserName = request.Email,
                PhoneNumber = request.Phone,
                Email = request.Email,
                Code = 1
            };
            var result = await userManager.CreateAsync(newUser, request.Password);
            var roleResult = await userManager.AddToRoleAsync(newUser, "Client");
            if (result.Succeeded)
            {
                return new RegisterResponse { Code = 200 };
            }
            return new RegisterResponse { Code = 418, Message = "I am teapot" };
        }

        public async Task<ValidateResult> Validate(RegisterRequest request)
        {
            var valpassword = !string.IsNullOrEmpty(request.Password);
            if(!valpassword)
            {
                return new ValidateResult { Code = 400, Message = "Password is empty" };
            }
            
            if (request.Password != request.ConfirmPassword)
            {
                return new ValidateResult { Code = 400, Message = "Passwords is not equals" };
            }
            return new ValidateResult();
        }

    }
}
