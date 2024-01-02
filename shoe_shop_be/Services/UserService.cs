using AutoMapper;
using shoe_shop_be.DTO;
using shoe_shop_be.Entities;
using shoe_shop_be.Errors;
using shoe_shop_be.Helpers;
using shoe_shop_be.Interfaces.IRepositories;
using shoe_shop_be.Interfaces.IServices;
using System;

namespace shoe_shop_be.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly IMapper _mapper;
        private readonly IPhotoService _photoService;
        public UserService(IUserRepository userRepository, IAccountRepository accountRepository, IMapper mapper, IPhotoService photoService)
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
            else
            {
                user.Avatar = null;
            }
            user.Address = firstLoginModel.Address;
            user.Age = firstLoginModel.Age;
            user.Gender = (Gender)Enum.Parse(typeof(Gender), firstLoginModel.Gender);
            user.Phone = firstLoginModel.Phone;
            user.Name = firstLoginModel.Name;
            account.UserId = user.Id;
            await _userRepository.Insert(user);
            _accountRepository.Update(account);
            await _userRepository.SaveChange();
            var userModel = _mapper.Map<UserModel>(user);
            return userModel;
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

        public async Task<UserModel> UpdateUser(FirstLoginModel firstLoginModel, string id)
        {
            var account = await _accountRepository.GetById(Guid.Parse(id));
            var user = await _userRepository.GetById(account.UserId);
            if(user == null)
            {
                throw new ApiException(400, "User is not register information", "");
            }
            if (firstLoginModel.Avatar != null)
            {
                var result = await _photoService.AddPhotoAsync(firstLoginModel.Avatar);
                if (result.Error != null)
                {
                    throw new ApiException(400, result.Error.Message, "");
                }
                user.Avatar = result.SecureUrl.AbsoluteUri;
            }
            else
            {
                user.Avatar = null;
            }
            user.Address = firstLoginModel.Address;
            user.Age = firstLoginModel.Age;
            user.Gender = (Gender)Enum.Parse(typeof(Gender), firstLoginModel.Gender);
            user.Phone = firstLoginModel.Phone;
            user.Name = firstLoginModel.Name;
            _userRepository.Update(user);
            await _userRepository.SaveChange();
            var userModel = _mapper.Map<UserModel>(user);
            return userModel;
        }
    }
}
