using Microsoft.EntityFrameworkCore;
using shoe_shop_be.Data;
using shoe_shop_be.Entities;
using shoe_shop_be.Interfaces.IRepositories;

namespace shoe_shop_be.Repositories
{
    public class AccountRepository : GenericRepository<Accounts>, IAccountRepository
    {
        public AccountRepository(DataContext dataContex) : base(dataContex) { }

        public async Task<IEnumerable<Accounts>> GetAllAccount(Guid id)
        {
            return await _dataContext.Accounts.Where(a => a.Id != id).ToListAsync();
        }

        public async Task<Accounts?> GetByEmail(string email)
        {
            return await _dataContext.Accounts.Where(a => a.Email == email).FirstOrDefaultAsync();
        }

        public async Task<Accounts?> GetByGoogleId(string googleId)
        {
            return await _dataContext.Accounts.Where(a => a.GoogleId == googleId).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Accounts>> GetBySearch(string search, Guid id)
        {
            return await _dataContext.Accounts.Where(a => a.Email.StartsWith(search) && a.Id != id).ToListAsync();
        }
    }
}
