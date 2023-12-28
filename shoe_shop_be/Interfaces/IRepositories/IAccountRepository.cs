using shoe_shop_be.Entities;

namespace shoe_shop_be.Interfaces.IRepositories
{
    public interface IAccountRepository : IGenericRepository<Accounts>{
        Task<Accounts?> GetByEmail(string email);
        Task<Accounts?> GetByGoogleId(string googleId);
        Task<IEnumerable<Accounts>> GetAllAccount(Guid id);
        Task<IEnumerable<Accounts>> GetBySearch(string search, Guid id);
    }
}
