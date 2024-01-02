using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using shoe_shop_be.DTO;
using shoe_shop_be.Interfaces.IServices;
using System.IdentityModel.Tokens.Jwt;

namespace shoe_shop_be.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult> GetUser()
        {
            var id = this.HttpContext.User.Claims.Where(c => c.Type == "id").FirstOrDefault();
            if(id == null)
            {
                return Unauthorized();
            }
            var res = await _userService.GetUser(id.Value);
            return Ok(res);
        }

        [HttpPost]
        public async Task<ActionResult> FirstLogin([FromForm]FirstLoginModel firstLoginModel)
        {
            var id = this.HttpContext.User.Claims.Where(c => c.Type == "id").FirstOrDefault();
            if (id == null)
            {
                return Unauthorized();
            }
            var res = await _userService.FirstLogin(firstLoginModel, id.Value);
            return Ok(res);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateUser([FromForm] FirstLoginModel firstLoginModel)
        {
            var id = this.HttpContext.User.Claims.Where(c => c.Type == "id").FirstOrDefault();
            if (id == null)
            {
                return Unauthorized();
            }
            var res = await _userService.UpdateUser(firstLoginModel, id.Value);
            return Ok(res);
        }

    }
}
