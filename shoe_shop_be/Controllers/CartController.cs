using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using shoe_shop_be.DTO;
using shoe_shop_be.Interfaces.IServices;

namespace shoe_shop_be.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class CartController : Controller
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [HttpPost]
        public async Task<IActionResult> AddToCart(CartModel cartModel)
        {
            var accountId = this.HttpContext.User.Claims.Where(c => c.Type == "id").FirstOrDefault();
            if(accountId == null)
            {
                return Unauthorized();
            }
            var res = _cartService.AddToCart(cartModel, Guid.Parse(accountId.Value));
            return Ok(res);
        }
    }
}
