using AutoMapper;
using shoe_shop_be.DTO;
using shoe_shop_be.Entities;
using shoe_shop_be.Interfaces.IRepositories;
using shoe_shop_be.Interfaces.IServices;
using shoe_shop_be.Models;
using System.Security.Cryptography;
using System.Text;

namespace shoe_shop_be.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IMapper _mapper;

        public AccountService(IAccountRepository accountRepository, IMapper mapper)
        {
            _accountRepository = accountRepository;
            _mapper = mapper;
        }
        public async Task<AccountsDto?> Register(RegisterModel registerModel)
        {
            var accountExist = await _accountRepository.GetByEmail(registerModel.Email);
            if (accountExist != null)
            {
                return null;
            }
            Accounts account = new Accounts();
            account.Email = registerModel.Email;
            var salt = BCrypt.Net.BCrypt.GenerateSalt();
            account.Password = BCrypt.Net.BCrypt.HashPassword(registerModel.Password, salt);
            account.Secret = salt;
            await _accountRepository.Insert(account);
            await _accountRepository.SaveChange();
            return new AccountsDto()
            {
                Email = account.Email
            };

        }

        public async Task<AccountsDto?> Login(LoginModel loginModel)
        {
            var accountExist = await _accountRepository.GetByEmail(loginModel.Email);
            if (accountExist == null)
            {
                return null;
            }
            string hashedPasswordToCheck = BCrypt.Net.BCrypt.HashPassword(loginModel.Password, accountExist.Secret);
            if (hashedPasswordToCheck != accountExist.Password)
            {
                return null;
            }
            AccountsDto accountsDto = _mapper.Map<AccountsDto>(accountExist);
            return accountsDto;
        }
    }
}
