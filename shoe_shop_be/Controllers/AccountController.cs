using AutoMapper;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using shoe_shop_be.Interfaces.IRepositories;
using shoe_shop_be.Interfaces.IServices;
using shoe_shop_be.RequestModels;

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
        public async Task<ActionResult> Register(RequestAccountModel requestAccountModel)
        {
            try
            {
                return await _accountService.Register(requestAccountModel);
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
