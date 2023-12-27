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
        private readonly IPhotoService _photoService;
        public UserService(IUserRepository userRepository, IAccountRepository accountRepository, IMapper mapper, IPhotoService photoService = null)
        {
            _userRepository = userRepository;
            _accountRepository = accountRepository;
            _mapper = mapper;
            _photoService = photoService;
        }

        public async Task<UserModel> FirstLogin(FirstLoginModel firstLoginModel, string id)
        {
            var account = await _accountRepository.GetById(Guid.Parse(id));

            if (account.UserId != null)
            {
                throw new ApiException(400, "User infomation alr registed", "");
            }
            User user = new User();
            if(firstLoginModel.Avatar != null)
            {
                var result = await _photoService.AddPhotoAsync(firstLoginModel.Avatar);
                if(result.Error != null) { 
                    throw new ApiException(400, result.Error.Message, "");
                }
                user.Avatar = result.SecureUrl.AbsoluteUri;
            }
            return new UserModel();
        }

        public async Task<UserModel> GetUser(string id)
        {
            var account = await _accountRepository.GetById(Guid.Parse(id));
           
            if(account == null)
            {
                throw new ApiException(400, "Account is not exist", "");
            }
            var user = await _userRepository.GetById(account.UserId);
            var userModel = _mapper.Map<UserModel>(user);
            return userModel;
        }


    }
}
