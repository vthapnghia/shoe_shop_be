using shoe_shop_be.Data;
using shoe_shop_be.Entities;
using shoe_shop_be.Interfaces.IRepositories;

namespace shoe_shop_be.Repositories
{
    public class ShipRepository : GenericRepository<Ships>, IShipRepository
    {
        public ShipRepository(DataContext dataContext) : base(dataContext)
        {
        }
    } 
}
