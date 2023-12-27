using AutoMapper;
using shoe_shop_be.DTO;
using shoe_shop_be.Entities;
using shoe_shop_be.Errors;
using shoe_shop_be.Interfaces.IRepositories;
using shoe_shop_be.Interfaces.IServices;

namespace shoe_shop_be.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly IMapper _mapper;
        public UserService(IUserRepository userRepository, IAccountRepository accountRepository, IMapper mapper) {
            _userRepository = userRepository;
            _accountRepository = accountRepository;
            _mapper = mapper;
        }
        public async Task<UserDto> GetUser(GetUserModel getUserModel)
        {
            var account = await _accountRepository.GetById(Guid.Parse(getUserModel.AccountId));
           
            if(account == null)
            {
                throw new ApiException(400, "Account is not exist", "");
            }
            var user = await _userRepository.GetById(account.UserId);
            var userDto = _mapper.Map<UserDto>(user);
            return userDto;
        }
    }
}
