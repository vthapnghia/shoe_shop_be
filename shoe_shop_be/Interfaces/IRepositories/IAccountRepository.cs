using shoe_shop_be.Entities;

namespace shoe_shop_be.Interfaces.IRepositories
{
    public interface IAccountRepository : GenericRepository<Accounts>{
        Task<bool> GetByEmail(string email);
    }
}
