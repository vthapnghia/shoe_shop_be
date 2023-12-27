using shoe_shop_be.DTO;
using shoe_shop_be.Entities;

namespace shoe_shop_be.Interfaces.IServices
{
    public interface IUserService
    {
        Task<UserDto> GetUser(GetUserModel getUserModel);
    }
}
