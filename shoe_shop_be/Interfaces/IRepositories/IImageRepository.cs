using shoe_shop_be.Entities;

namespace shoe_shop_be.Interfaces.IRepositories
{
    public interface IImageRepository: IGenericRepository<Images>
    {
        Task<List<Images>> GetAllByProduct(Guid productId);
    }
}
