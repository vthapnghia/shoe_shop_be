using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using shoe_shop_be.DTO;
using shoe_shop_be.Interfaces.IServices;

namespace shoe_shop_be.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class LikeController : ControllerBase
    {
        private readonly ILikeService _likeService;

        public LikeController(ILikeService likeService) {
            _likeService = likeService;
        }

        [HttpGet]
        public async Task<ActionResult> GetLikeList()
        {
            var accountId = this.HttpContext.User.Claims.Where(c => c.Type == "id").FirstOrDefault();
            if (accountId == null)
            {
                return Unauthorized();
            }
            var res = await _likeService.GetLikeList(Guid.Parse(accountId.Value));
            return Ok(res);
        }

        [HttpPost]
        public async Task<ActionResult> AddToLikeList(LikeModel likeModel)
        {
            var accountId = this.HttpContext.User.Claims.Where(c => c.Type == "id").FirstOrDefault();
            if (accountId == null)
            {
                return Unauthorized();
            }
            var res = await _likeService.AddToLikeList(likeModel, Guid.Parse(accountId.Value));
            return Ok(res);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> RemoveFromLikeList(Guid id)
        {
            var accountId = this.HttpContext.User.Claims.Where(c => c.Type == "id").FirstOrDefault();
            if (accountId == null)
            {
                return Unauthorized();
            }
            var res = await _likeService.RemoveFromLikeList(id, Guid.Parse(accountId.Value));
            return Ok(res);
        }
    }
}
