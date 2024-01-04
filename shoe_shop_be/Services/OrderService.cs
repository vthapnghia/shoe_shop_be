using shoe_shop_be.DTO;
using shoe_shop_be.Interfaces.IServices;

namespace shoe_shop_be.Services
{
    public class OrderService : IOrderService
    {
        public Task<OrderDto> CreateOrder(OrderModel orderModel, Guid accountId)
        {
            throw new NotImplementedException();
        }
    }
}
