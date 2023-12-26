﻿using Microsoft.EntityFrameworkCore;
using shoe_shop_be.Data;
using shoe_shop_be.Entities;
using shoe_shop_be.Interfaces.IRepositories;

namespace shoe_shop_be.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(DataContext dataContext) : base(dataContext)
        { }
    }
}
