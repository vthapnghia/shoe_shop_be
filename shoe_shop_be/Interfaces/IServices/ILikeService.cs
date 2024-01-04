using shoe_shop_be.DTO;

namespace shoe_shop_be.Interfaces.IServices
{
    public interface ILikeService
    {
        Task<LikeDto> AddToLikeList(LikeModel likeModel, Guid accountId);
        Task<bool> RemoveFromLikeList(Guid id, Guid accountId);
        Task<List<ProductDto>> GetLikeList(Guid accountId);
    }
}
