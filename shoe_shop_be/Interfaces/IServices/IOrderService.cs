using shoe_shop_be.DTO;

namespace shoe_shop_be.Interfaces.IServices
{
    public interface IOrderService
    {
        Task<OrderDto> CreateOrder(OrderModel orderModel, Guid accountId);
    }
}
