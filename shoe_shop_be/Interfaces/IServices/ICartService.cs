using shoe_shop_be.DTO;
using shoe_shop_be.Entities;

namespace shoe_shop_be.Interfaces.IServices
{
    public interface ICartService
    {
        Task<Cart> AddToCart(CartModel cartModel, Guid accountId);
        Task<IList<CartDto>> GetAll(Guid accountId);
    }
}
