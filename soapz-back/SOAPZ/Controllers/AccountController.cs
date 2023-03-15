using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SOAPZ.Operations.Login;
using SOAPZ.Operations.Register;
using SOAPZ.Services;

namespace SOAPZ.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IServiceProvider _serviceProvider;
        AccountService accountService;


        public AccountController(IServiceProvider serviceProvider, AccountService accountService)
        {
            _serviceProvider = serviceProvider;
            this.accountService = accountService;
        }

        [HttpPost("Register")]
        public async Task<ActionResult> Register(RegisterRequest request)
        {
            return new JsonResult(await accountService.RegisterOperation(request));
        }

        [HttpPost("Login")]
        public async Task<ActionResult> Login(LoginRequest request)
        {
            return new JsonResult(await accountService.LoginOperation(request));
        }
    }
}
