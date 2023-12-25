using AutoMapper;
using shoe_shop_be.DTO;
using shoe_shop_be.Entities;
using shoe_shop_be.Helpers;
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
        private readonly IMailService _mailService;
        private readonly IUserrepository _userRepository;
        private readonly ITokenService _tokenService;

        public AccountService(
            IAccountRepository accountRepository, 
            IMapper mapper, 
            IMailService mailService, 
            IUserrepository userRepository, 
            ITokenService tokenService)
        {
            _accountRepository = accountRepository;
            _mapper = mapper;
            _mailService = mailService;
            _userRepository = userRepository;
            _tokenService = tokenService;
        }
        public async Task<AccountsDto> Register(RegisterModel registerModel)
        {
            var accountExist = await _accountRepository.GetByEmail(registerModel.Email);
            AccountsDto accountsDto = new AccountsDto();
            accountsDto.Email = registerModel.Email;
            if (accountExist != null)
            {
                accountsDto.StatusCode = 400;
                accountsDto.StatusMessage = "Email is exist";
                return accountsDto;
            }
            Accounts account = new Accounts();
            account.Email = registerModel.Email;
            var salt = BCrypt.Net.BCrypt.GenerateSalt();
            account.Password = BCrypt.Net.BCrypt.HashPassword(registerModel.Password, salt);
            account.Secret = new Random().Next(100000, 999999).ToString();

            MailData mailData = new MailData()
            {
                EmailToId = account.Email,
                EmailToName = account.Email,
                EmailSubject = "Shoes shop verify email",
                EmailBody = "Mã xác nhận đăng ký của bạn ở shoeShop là: " + account.Secret,
            };

            if (!_mailService.SendMail(mailData))
            {
                accountsDto.StatusCode = 500;
                accountsDto.StatusMessage = "Send mail is fail";
                return accountsDto;
            }
            await _accountRepository.Insert(account);
            await _accountRepository.SaveChange();
            var accountDtoRes = _mapper.Map<AccountsDto>(account);
            accountDtoRes.StatusCode = 200;
            accountDtoRes.StatusMessage = "Register is success";
            return accountDtoRes;
        }

        public async Task<LoginResponseModel> Login(LoginModel loginModel)
        {
            var accountExist = await _accountRepository.GetByEmail(loginModel.Email);
            LoginResponseModel loginResponseModel = new LoginResponseModel();
            if (accountExist == null)
            {
                loginResponseModel.User = new UserDto();
                loginResponseModel.StatusCode = 400;
                loginResponseModel.StatusMessage = "Email is not exist";
                return loginResponseModel;
            }
            bool hashedPasswordToCheck = BCrypt.Net.BCrypt.Verify(loginModel.Password, accountExist.Password);
            if (!hashedPasswordToCheck)
            {
                loginResponseModel.User = new UserDto();
                loginResponseModel.StatusCode = 400;
                loginResponseModel.StatusMessage = "Password is incorrect";
                return loginResponseModel;
            }
            var user = await _userRepository.GetById(accountExist.UserId);
            loginResponseModel.User = _mapper.Map<UserDto>(user);
            loginResponseModel.Token = _tokenService.CreateToken(accountExist.Id);
            loginResponseModel.StatusCode = 200;
            loginResponseModel.StatusMessage = "Login is success";
            loginResponseModel.IsSeller = accountExist.IsSeller;
            loginResponseModel.IsAdmin = accountExist.IsAdmin;
            return loginResponseModel;
        }

        public async Task<bool> Verify(VerifyModel verifyModel, string id)
        {
            var account = await _accountRepository.GetById(Guid.Parse(id));
            if (account != null && account.Secret == verifyModel.Secret)
            {
                return true;
            }
            return false;
        }
    }
}
