using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using shoe_shop_be.DTO;
using shoe_shop_be.Interfaces.IServices;

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
        public async Task<ActionResult> Register(RegisterModel registerModel)
        {
            var res = await _accountService.Register(registerModel);
            return Ok(res);
        }

        [HttpPost("verify/{id}")]
        public async Task<ActionResult> Verify([FromBody] VerifyModel verifyModel, string id)
        {
            var verify = await _accountService.Verify(verifyModel, id);
            if (!verify)
            {
                return BadRequest("Code is incorrect");
            }
            return Ok("Verify is success");
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login(LoginModel loginModel)
        {
            var res = await _accountService.Login(loginModel);
            return Ok(res);
        }

        [HttpPost("resetPassword")]
        public async Task<ActionResult> ResetPassword(ResetPasswordModel resetPasswordModel)
        {
            var res = await _accountService.ResetPassword(resetPasswordModel);
            return Ok(res);
        }

        [HttpPost("resetPassword/verify")]
        public async Task<ActionResult> VerifyResetPassword(VerifyRegisterPasswordModel verifyRegisterPasswordModel)
        {
            var res = await _accountService.VerifyResetPassword(verifyRegisterPasswordModel);
            if (!res)
            {
                return BadRequest("Lỗi");
            }
            return Ok("Reset password is success");
        }

        [HttpPost("admin")]
        public async Task<ActionResult> LoginAdmin(LoginModel loginModel)
        {
            var res = await _accountService.LoginAdmin(loginModel);
            return Ok(res);
        }

        [HttpPost("google")]
        public async Task<ActionResult> LoginGoogle(LoginGoogleModel loginGoogleModel)
        {
            var res = await _accountService.LoginGoogle(loginGoogleModel);
            return Ok(res);
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<AccountsDto>>> GetAllAccount()
        {
            var id = this.HttpContext.User.Claims.Where(c => c.Type == "id").FirstOrDefault();
            if(id == null)
            {
                return Unauthorized();
            }
            var res = await _accountService.GetAllAccount(id.Value);
            return Ok(res);
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult> DeleteAccount(string id)
        {
            var idLogin = this.HttpContext.User.Claims.Where(c => c.Type == "id").FirstOrDefault();
            if(idLogin == null)
            {
                return Unauthorized();
            }
            var res = await _accountService.DeleteAccount(id, idLogin.Value);
            return Ok(res);
        }

        [HttpGet("search")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<AccountsDto>>> SearchAccount([FromQuery(Name = "search")] string search)
        {
            var id = this.HttpContext.User.Claims.Where(c => c.Type == "id").FirstOrDefault();
            if (id == null)
            {
                return Unauthorized();
            }
            var res = await _accountService.SearchAccount(search, id.Value);
            return Ok(res);
        }
    }
}
