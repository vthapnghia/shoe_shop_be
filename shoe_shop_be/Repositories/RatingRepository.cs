using shoe_shop_be.Data;
using shoe_shop_be.Entities;
using shoe_shop_be.Interfaces.IRepositories;

namespace shoe_shop_be.Repositories
{
    public class RatingRepository : GenericRepository<Ratings>, IRatingRepository
    {
        public RatingRepository(DataContext dataContext) : base(dataContext)
        {
        }
    }
}
