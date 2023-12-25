using Microsoft.AspNetCore.Mvc;

namespace shoe_shop_be.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateProduct()
        {

            return Ok();
        }
        
    }
}
