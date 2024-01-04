using shoe_shop_be.Entities;

namespace shoe_shop_be.DTO
{
    public class OrderDto
    {
        public Guid Id { get; set; }
        public int Total { get; set; }
        public int Status { get; set; }
        public Guid ShipId { get; set; }
        public int PaymentMethod { get; set; }
        public DateTime CompleDate { get; set; }
        public Guid AccountId { get; set; }
        public Guid PromotionId { get; set; }
        public string Location { get; set; }
        public string ReceiverName { get; set; }
        public string ReceiverPhone { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
