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

            AccountsDto accountsDto = await _accountService.Register(registerModel);
            if (accountsDto.StatusCode != 200)
            {
                return BadRequest(accountsDto.StatusMessage);
            }
            return Ok(accountsDto);
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
            if (res.StatusCode != 200)
            {
                return BadRequest(res.StatusMessage);
            }
            return Ok(res);
        }
    }
}
