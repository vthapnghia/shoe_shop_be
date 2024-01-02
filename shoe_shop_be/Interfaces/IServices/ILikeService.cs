using shoe_shop_be.DTO;

namespace shoe_shop_be.Interfaces.IServices
{
    public interface ILikeService
    {
        Task<LikeDto> AddToLikeList(LikeModel likeModel, string accountId);
        Task<bool> RemoveFromLikeList(string id, string accountId);
        Task<List<ProductDto>> GetLikeList(string accountId);
    }
}
