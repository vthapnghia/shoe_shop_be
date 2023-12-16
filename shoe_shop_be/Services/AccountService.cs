using Microsoft.AspNetCore.Mvc;
using shoe_shop_be.DTO;
using shoe_shop_be.Entities;
using shoe_shop_be.Interfaces.IRepositories;
using shoe_shop_be.Interfaces.IServices;
using shoe_shop_be.Repositories;
using shoe_shop_be.RequestModels;
using System.Security.Cryptography;

namespace shoe_shop_be.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;

        public AccountService(AccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        public async Task<AccountsDto> Register(RequestAccountModel requestAccountModel)
        {
            
            return null;
        }
    }
}
