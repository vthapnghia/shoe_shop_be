using Microsoft.AspNetCore.Mvc;
using shoe_shop_be.DTO;
using shoe_shop_be.Interfaces.IServices;
using shoe_shop_be.Models;

namespace shoe_shop_be.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterModel registerModel)
        {
            var res = await _accountService.Register(registerModel);
            return Ok(res);
        }

        [HttpPost("verify/{id}")]
        public async Task<IActionResult> Verify([FromBody] VerifyModel verifyModel, string id)
        {
            var verify = await _accountService.Verify(verifyModel, id);
            if (!verify)
            {
                return BadRequest("Code is incorrect");
            }
            return Ok("Verify is success");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            var res = await _accountService.Login(loginModel);
            return Ok(res);
        }

        [HttpPost("resetPassword")]
        public async Task<IActionResult> ResetPassword(ResetPasswordModel resetPasswordModel)
        {
            var res = await _accountService.ResetPassword(resetPasswordModel);
            return Ok(res);
        }

        [HttpPost("resetPassword/verify")]
        public async Task<IActionResult> VerifyResetPassword(VerifyRegisterPasswordModel verifyRegisterPasswordModel)
        {
            var res = await _accountService.VerifyResetPassword(verifyRegisterPasswordModel);
            if (!res)
            {
                return BadRequest("Lỗi");
            }
            return Ok("Reset password is success");
        }

        [HttpPost("admin")]
        public async Task<IActionResult> LoginAdmin(LoginModel loginModel)
        {
            var res = await _accountService.LoginAdmin(loginModel);
            return Ok(res);
        }

        [HttpPost("google")]
        public async Task<IActionResult> LoginGoogle(LoginGoogleModel loginGoogleModel)
        {
            var res = await _accountService.LoginGoogle(loginGoogleModel);
            return Ok(res);
        }
    }
}
