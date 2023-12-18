using Microsoft.AspNetCore.Mvc;
using shoe_shop_be.Interfaces.IServices;
using shoe_shop_be.Models;

namespace shoe_shop_be.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register(RegisterModel registerModel)
        {

            var account = await _accountService.Register(registerModel);
            if (account == null)
            {
                return BadRequest("Email is exist");
            }
            return Ok(account?.Email);
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login(LoginModel loginModel)
        {


            var account = await _accountService.Login(loginModel);
            if (account == null)
            {
                return BadRequest("Email is not exist");
            }
            return Ok(account);
        }
    }
}
