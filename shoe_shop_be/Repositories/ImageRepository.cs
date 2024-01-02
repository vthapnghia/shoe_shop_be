using Microsoft.EntityFrameworkCore;
using shoe_shop_be.Data;
using shoe_shop_be.Entities;
using shoe_shop_be.Interfaces.IRepositories;

namespace shoe_shop_be.Repositories
{
    public class ImageRepository : GenericRepository<Images>, IImageRepository
    {
        public ImageRepository(DataContext dataContext) : base(dataContext)
        {
        }

        public async Task<List<Images>> GetAllByProduct(Guid productId)
        {
            return await _dataContext.Images.Where(i => i.ProductId == productId).ToListAsync();
        }
    }
}
