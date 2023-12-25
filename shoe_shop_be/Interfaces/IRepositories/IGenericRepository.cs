namespace shoe_shop_be.Interfaces.IRepositories
{
    public interface IGenericRepository<T>
    {
        public IQueryable<T> Get();
        public Task<IEnumerable<T>> GetAll();
        public Task<T> GetById(object id);
        public Task Insert(T entity);
        public void Update(T entity);
        public void Delete(T entity);
        public Task<bool> SaveChange();
    }
}
