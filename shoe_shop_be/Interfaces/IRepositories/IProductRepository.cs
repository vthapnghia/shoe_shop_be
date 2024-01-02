﻿using shoe_shop_be.Entities;

namespace shoe_shop_be.Interfaces.IRepositories
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<List<Product>> GetBySearch(string search);
    }
}


