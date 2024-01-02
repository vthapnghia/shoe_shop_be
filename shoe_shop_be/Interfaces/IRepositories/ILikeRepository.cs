using shoe_shop_be.Entities;

namespace shoe_shop_be.Interfaces.IRepositories
{
    public interface ILikeRepository : IGenericRepository<Likes>
    {
        Task<Likes?> GetBYUserIdAndProductId(Guid productId, Guid userId);
        Task<List<Likes>> GetByAccountId(Guid accountId);
    }
}
