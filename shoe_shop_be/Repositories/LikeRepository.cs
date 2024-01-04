using Microsoft.EntityFrameworkCore;
using shoe_shop_be.Data;
using shoe_shop_be.Entities;
using shoe_shop_be.Interfaces.IRepositories;

namespace shoe_shop_be.Repositories
{
    public class LikeRepository : GenericRepository<Likes>, ILikeRepository
    {
        public LikeRepository(DataContext dataContext) : base(dataContext)
        {
        }

        public async Task<List<Likes>> GetByAccountId(Guid accountId)
        {
            return await _dataContext.Likes.Where(l => l.AccountId == accountId && l.Delete == false).Include(l => l.Product).ThenInclude(g => g.ProductImages).ToListAsync();
        }

        public async Task<Likes?> GetBYUserIdAndProductId(Guid productId, Guid userId)
        {
            return await _dataContext.Likes.Where(l => l.ProductId == productId && l.AccountId == userId).FirstOrDefaultAsync();
        }
    }
}
