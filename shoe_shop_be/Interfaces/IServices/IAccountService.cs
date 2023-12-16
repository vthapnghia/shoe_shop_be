using shoe_shop_be.RequestModels;

namespace shoe_shop_be.Interfaces.IServices
{
    public interface IAccountService
    {
        Task Register(RequestAccountModel requestAccountModel);
    }
}
