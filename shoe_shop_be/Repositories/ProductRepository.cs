using Microsoft.EntityFrameworkCore;
using shoe_shop_be.Data;
using shoe_shop_be.Entities;
using shoe_shop_be.Interfaces.IRepositories;

namespace shoe_shop_be.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(DataContext dataContext) : base(dataContext)
        {
        }

        public async Task<List<Product>> GetAllProduct()
        {
            return await _dataContext.Products.Where(p => p.IsActive == true).Include(p => p.ProductImages).ToListAsync();
        }

        public async Task<List<Product>> GetBySearch(string search)
        {
            return await _dataContext.Products.Where(p => p.Name.StartsWith(search) && p.IsActive == true).Include(p => p.ProductImages).ToListAsync();
        }

        public async Task<Product?> GetProductById(Guid id)
        {
            return await _dataContext.Products.Where(p => p.Id == id && p.IsActive == true).Include(p => p.ProductImages).FirstOrDefaultAsync();
        }
    }
}
