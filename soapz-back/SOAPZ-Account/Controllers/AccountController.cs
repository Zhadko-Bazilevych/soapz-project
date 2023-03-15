using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SOAPZ_Account.Operations.Login;
using SOAPZ_Account.Operations.Logout;
using SOAPZ_Account.Operations.Register;

namespace SOAPZ_Account.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IServiceProvider _serviceProvider;

        public AccountController(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        [HttpPost("Register")]
        public async Task<ActionResult> Register(RegisterRequest request)
        {
            var operation = _serviceProvider.GetRequiredService<RegisterOperation>();
            var result = await operation.Execute(request);

            return new JsonResult(result);
        }

        [HttpPost("Login")]
        public async Task<ActionResult> Login(LoginRequest request)
        {
            var operation = _serviceProvider.GetRequiredService<LoginOperation>();
            var result = await operation.Execute(request);
            //if (result.Code != 200)
            //{
            //    return StatusCode(result.Code, result.Message);
            //}
            return new JsonResult(result);
        }

        /*HERE*/
        [HttpPost("Logout")]
        public async Task<ActionResult> Logout(LogoutRequest request)
        {
            var operation = _serviceProvider.GetRequiredService<LogoutOperation>();
            var result = await operation.Execute(request);
            if (result.Code != 200)
            {
                return StatusCode(result.Code, result.Message);
            }
            return new JsonResult(result);
        }
    }
}
