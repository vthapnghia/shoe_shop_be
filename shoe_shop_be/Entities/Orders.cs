using shoe_shop_be.Interfaces.EntityInterfaces;

namespace shoe_shop_be.Entities
{
    public class Orders: ICreatedAt
    {
        public Guid Id { get; set; }
        public int Total { get; set; }
        public int Status { get; set; }
        public List<OrderDetails> Details { get; set; }
        public Guid ShipId { get; set; }
        public Ships Ship { get; set; }
        public int PaymentMethod { get; set; }
        public DateTime CompleDate { get; set; }
        public Guid AccountId { get; set; }
        public Accounts Account { get; set; }
        public Guid PromotionId { get; set; }
        public Promotions Promotion { get; set; }
        public string Location { get; set; }
        public string ReceiverName { get; set; }
        public string ReceiverPhone { get; set; }
        public DateTime? CreatedAt { get ; set; }
    }
}
