using AutoMapper;
using Microsoft.AspNetCore.Server.IIS.Core;
using shoe_shop_be.DTO;
using shoe_shop_be.Entities;
using shoe_shop_be.Errors;
using shoe_shop_be.Helpers;
using shoe_shop_be.Interfaces.IRepositories;
using shoe_shop_be.Interfaces.IServices;
using System.Security.Cryptography;
using System.Text;

namespace shoe_shop_be.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IMapper _mapper;
        private readonly IMailService _mailService;
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;

        public AccountService(
            IAccountRepository accountRepository,
            IMapper mapper,
            IMailService mailService,
            IUserRepository userRepository,
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
            if (accountExist != null)
            {
                throw new ApiException(400, "Email is exist", "");
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
                throw new ApiException(500, "Send mail is fail", "");
            }
            await _accountRepository.Insert(account);
            await _accountRepository.SaveChange();
            var accountDto = _mapper.Map<AccountsDto>(account);
            return accountDto;
        }

        public async Task<LoginResponseModel> Login(LoginModel loginModel)
        {
            var accountExist = await _accountRepository.GetByEmail(loginModel.Email);
            if (accountExist == null)
            {
                throw new ApiException(400, "Email is not exist", "");
            }
            bool hashedPasswordToCheck = BCrypt.Net.BCrypt.Verify(loginModel.Password, accountExist.Password);
            if (!hashedPasswordToCheck)
            {
                throw new ApiException(400, "Password is incorrect", "");
            }
            var user = await _userRepository.GetById(accountExist.UserId);
            LoginResponseModel loginResponseModel = new LoginResponseModel();
            loginResponseModel.User = _mapper.Map<UserDto>(user);
            loginResponseModel.Token = _tokenService.CreateToken(accountExist.Id);
            loginResponseModel.IsSeller = accountExist.IsSeller;
            loginResponseModel.IsAdmin = accountExist.IsAdmin;
            return loginResponseModel;
        }

        public async Task<bool> Verify(VerifyModel verifyModel, string id)
        {
            var account = await _accountRepository.GetById(Guid.Parse(id));
            if (account != null && account.Secret == verifyModel.Secret)
            {
                account.IsActive = true;
                _accountRepository.Update(account);
                await _accountRepository.SaveChange();
                return true;
            }
            return false;
        }

        public async Task<AccountsDto> ResetPassword(ResetPasswordModel resetPasswordModel)
        {
            var account = await _accountRepository.GetByEmail(resetPasswordModel.Email);
            if (account == null || !account.IsActive)
            {
                throw new ApiException(400, "Email is not exist", "");
            }
            var secret = new Random().Next(100000, 999999).ToString();
            MailData mailData = new MailData()
            {
                EmailToId = account.Email,
                EmailToName = account.Email,
                EmailSubject = "Shoes shop verify email",
                EmailBody = "Mã đặt lại mật khẩu của bạn ở shoeShop là: " + secret,
            };

            if (!_mailService.SendMail(mailData))
            {
                throw new ApiException(500, "Send mail is fail", "");
            }
            account.Secret = secret;
            _accountRepository.Update(account);
            await _accountRepository.SaveChange();
            var accountDtoRes = _mapper.Map<AccountsDto>(account);
            return accountDtoRes;
        }

        public async Task<bool> VerifyResetPassword(VerifyRegisterPasswordModel verifyRegisterPasswordModel)
        {
            var account = await _accountRepository.GetByEmail(verifyRegisterPasswordModel.Email);
            if (account != null && account.Secret == verifyRegisterPasswordModel.Secret)
            {
                var salt = BCrypt.Net.BCrypt.GenerateSalt();
                account.Password = BCrypt.Net.BCrypt.HashPassword(verifyRegisterPasswordModel.Password, salt);
                _accountRepository.Update(account);
                await _accountRepository.SaveChange();
                return true;
            }
            return false;
        }

        public async Task<LoginResponseModel> LoginAdmin(LoginModel loginModel)
        {
            var accountExist = await _accountRepository.GetByEmail(loginModel.Email);
            LoginResponseModel loginResponseModel = new LoginResponseModel();
            if (accountExist == null || (accountExist.IsAdmin == false && accountExist.IsSeller == false))
            {
                throw new ApiException(400, "Email is not exist", "");
            }
            bool hashedPasswordToCheck = BCrypt.Net.BCrypt.Verify(loginModel.Password, accountExist.Password);
            if (!hashedPasswordToCheck)
            {
                throw new ApiException(400, "Password is incorrect", "");
            }
            var user = await _userRepository.GetById(accountExist.UserId);
            loginResponseModel.User = _mapper.Map<UserDto>(user);
            loginResponseModel.Token = _tokenService.CreateToken(accountExist.Id);
            loginResponseModel.IsSeller = accountExist.IsSeller;
            loginResponseModel.IsAdmin = accountExist.IsAdmin;
            return loginResponseModel;
        }

        public async Task<LoginResponseModel> LoginGoogle(LoginGoogleModel loginGoogleModel)
        {
            var accountExist = await _accountRepository.GetByGoogleId(loginGoogleModel.GoogleId);
            LoginResponseModel loginResponseModel = new LoginResponseModel();
            if (accountExist == null)
            {
                Accounts accounts = new Accounts()
                {
                    UserId = null,
                    User = null,
                    Email = "",
                    Password = "",
                    IsAdmin = false,
                    IsActive = true,
                    IsSeller = false,
                    CreatedAt = null,
                    Secret = "",
                    GoogleId = loginGoogleModel.GoogleId,
                };
                _accountRepository.Insert(accounts);
                _accountRepository.SaveChange();
                loginResponseModel.User = new UserDto();
                loginResponseModel.Token = _tokenService.CreateToken(accounts.Id);
                loginResponseModel.IsSeller = false;
                loginResponseModel.IsAdmin = false;
                return loginResponseModel;
            }
            var user = await _userRepository.GetById(accountExist.UserId);
            loginResponseModel.User = _mapper.Map<UserDto>(user);
            loginResponseModel.Token = _tokenService.CreateToken(accountExist.Id);
            loginResponseModel.IsSeller = false;
            loginResponseModel.IsAdmin = false;
            return loginResponseModel;
        }
    }
}
