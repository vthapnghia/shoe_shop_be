using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Metadata;
using Microsoft.AspNetCore.Mvc;
using shoe_shop_be.DTO;
using shoe_shop_be.Interfaces.IServices;

namespace shoe_shop_be.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class BrandController : ControllerBase
    {
        private readonly IBrandService _brandService;

        public BrandController(IBrandService brandService) { 
            _brandService = brandService;
        }

        [HttpPost]
        public async Task<ActionResult> CreateBrand(BrandModel brandModel)
        {
            var id = this.HttpContext.User.Claims.Where(c => c.Type == "id").FirstOrDefault();
            if (id == null)
            {
                return Unauthorized();
            }
            var res = await _brandService.CreateBrand(brandModel, id.Value);
            return Ok(res);
        }

        [HttpGet]
        public async Task<IEnumerable<BrandDto>> GetAllBrand()
        {
            return await _brandService.GetAllBrand();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetBrand(string id)
        {
            var res = await _brandService.GetBrand(id);
            return Ok(res);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBrand(string id)
        {
            var loginId = this.HttpContext.User.Claims.Where(c => c.Type == "id").FirstOrDefault();
            if (loginId == null)
            {
                return Unauthorized();
            }
            await _brandService.DeleteBrand(id, loginId.Value);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateBrand([FromBody] BrandModel brandModel ,string id)
        {
            var loginId = this.HttpContext.User.Claims.Where(c => c.Type == "id").FirstOrDefault();
            if (loginId == null)
            {
                return Unauthorized();
            }
            await _brandService.UpdateBrand(brandModel, id, loginId.Value);
            return Ok();
        }
    }
}
