using Microsoft.EntityFrameworkCore;
using shoe_shop_be.Data;
using shoe_shop_be.Entities;
using shoe_shop_be.Interfaces.IRepositories;

namespace shoe_shop_be.Repositories
{
    public class AccountRepository : GenericRepository<Accounts>, IAccountRepository
    {
        public AccountRepository(DataContext dataContex): base(dataContex) { }

        public async Task<bool> GetByEmail(string email)
        {
            return (await _dataContext.Accounts.Where(a => a.Email == email).FirstOrDefaultAsync()) == null;
        }
    }
}
