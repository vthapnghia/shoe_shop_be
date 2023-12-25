using shoe_shop_be.DTO;
using shoe_shop_be.Models;

namespace shoe_shop_be.Interfaces.IServices
{
    public interface IAccountService
    {
        Task<AccountsDto> Register(RegisterModel requestAccountModel);
        Task<bool> Verify(VerifyModel verifyModel, string id);
        Task<LoginResponseModel> Login(LoginModel loginModel);
    }
}
