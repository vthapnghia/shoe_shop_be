using Microsoft.EntityFrameworkCore;
using shoe_shop_be.Data;
using shoe_shop_be.Interfaces.IRepositories;

namespace shoe_shop_be.Repositories
{
    public class GenericRepository<T> : Interfaces.IRepositories.GenericRepository<T> where T : class
    {
        protected readonly DataContext _dataContext;
        public GenericRepository(DataContext dataContext) 
        { 
            _dataContext = dataContext;
        }

        public void Delete(T entity)
        {
            _dataContext.Remove(entity);
        }

        public IQueryable<T> Get()
        {
            return _dataContext.Set<T>().AsQueryable();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
           return await _dataContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetById(object id)
        {
            return await _dataContext.FindAsync<T>(id);
        }

        public async Task Insert(T entity)
        {
            await _dataContext.AddAsync<T>(entity);
        }

        public async Task<bool> SaveChange()
        {
            return await _dataContext.SaveChangesAsync() != 0;
        }

        public void Update(T entity)
        {
             _dataContext.Update<T>(entity);
        }
    }
}
