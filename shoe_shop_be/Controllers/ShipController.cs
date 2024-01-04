using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using shoe_shop_be.DTO;
using shoe_shop_be.Interfaces.IRepositories;
using shoe_shop_be.Interfaces.IServices;

namespace shoe_shop_be.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class ShipController : ControllerBase
    {
        private readonly IShipService _shipService;
        public ShipController(IShipService shipService) {
            _shipService = shipService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetShip(string id)
        {
            var res = await _shipService.GetShips(id);
            return Ok(res);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllShip()
        {
            var res = await _shipService.GetAllShips();
            return Ok(res);
        }

        [HttpPost]
        public async Task<IActionResult> CreateShip(ShipModel shipModel)
        {
            var accountId = this.HttpContext.User.Claims.Where(c => c.Type == "id").FirstOrDefault();
            if (accountId == null)
            {
                return Unauthorized();
            }
            var res = await _shipService.CreateShip(shipModel, accountId.Value);
            return Ok(res);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateShip(string id, ShipModel shipModel)
        {
            var accountId = this.HttpContext.User.Claims.Where(c => c.Type == "id").FirstOrDefault();
            if (accountId == null)
            {
                return Unauthorized();
            }
            var res = await _shipService.UpdateShip(id ,shipModel, accountId.Value);
            return Ok(res);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShip(string id)
        {
            var accountId = this.HttpContext.User.Claims.Where(c => c.Type == "id").FirstOrDefault();
            if (accountId == null)
            {
                return Unauthorized();
            }
            var res = await _shipService.DeleteShip(id, accountId.Value);
            return Ok(res);
        }
    }
}
