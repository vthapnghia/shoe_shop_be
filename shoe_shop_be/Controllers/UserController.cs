﻿using Microsoft.AspNetCore.Authorization;
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
            var id = this.HttpContext.User.Claims.Where(c => c.Type == "id").FirstOrDefault();
            if(id == null)
            {
                return BadRequest();
            }
            var res = await _userService.GetUser(id.Value);
            return Ok(res);
        }

        [HttpPost]
        public async Task<IActionResult> FirstLogin(FirstLoginModel firstLoginModel)
        {
            var id = this.HttpContext.User.Claims.Where(c => c.Type == "id").FirstOrDefault();
            if (id == null)
            {
                return BadRequest();
            }
            var res = await _userService.FirstLogin(firstLoginModel, id.Value);
            return Ok(res);
        }
    }
}
