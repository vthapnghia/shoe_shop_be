using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using shoe_shop_be.DTO;
using shoe_shop_be.Interfaces.IServices;
using System.IdentityModel.Tokens.Jwt;

namespace shoe_shop_be.Controllers
{
    [Route("[controller]")]
    [Controller]
    [Authorize]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetUser()
        {
            var accessToken = HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(accessToken) as JwtSecurityToken;
            var id = jsonToken?.Claims.FirstOrDefault(c => c.Type == "id")?.Value;
            var res = await _userService.GetUser(id);
            return Ok(res);
        }

        [HttpPost]
        public async Task<IActionResult> FirstLogin(FirstLoginModel firstLoginModel)
        {
            var accessToken = HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(accessToken) as JwtSecurityToken;
            var id = jsonToken?.Claims.FirstOrDefault(c => c.Type == "id")?.Value;
            var res = await _userService.FirstLogin(firstLoginModel, id);
            return Ok(res);
        }
    }
}
