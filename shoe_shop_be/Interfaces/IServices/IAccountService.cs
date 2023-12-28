using shoe_shop_be.DTO;
using System.Threading.Tasks;

namespace shoe_shop_be.Interfaces.IServices
{
    public interface IAccountService
    {
        Task<AccountsDto> Register(RegisterModel requestAccountModel);
        Task<bool> Verify(VerifyModel verifyModel, string id);
        Task<LoginResponseModel> Login(LoginModel loginModel);
        Task<AccountsDto> ResetPassword(ResetPasswordModel resetPasswordModel);
        Task<bool> VerifyResetPassword(VerifyRegisterPasswordModel verifyRegisterPasswordModel);
        Task<LoginResponseModel> LoginAdmin(LoginModel loginModel);
        Task<LoginResponseModel> LoginGoogle(LoginGoogleModel loginGoogleModel);
        Task<IEnumerable<AccountsDto>> GetAllAccount(string id);
        Task<AccountsDto> DeleteAccount(string id, string idLogin);
        Task<IEnumerable<AccountsDto>> SearchAccount(string search, string id);
    }
}
