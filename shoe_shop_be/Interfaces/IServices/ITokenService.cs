using shoe_shop_be.DTO;

namespace shoe_shop_be.Interfaces.IServices
{
    public interface ITokenService
    {
        public string CreateToken(Guid accountId);
    }
}
