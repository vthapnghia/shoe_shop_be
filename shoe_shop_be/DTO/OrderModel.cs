using System.ComponentModel.DataAnnotations;

namespace shoe_shop_be.DTO
{
    public class OrderModel
    {
        [Required]
        public List<ProductItem> Items { get; set; }
        [Required]
        public double Total { get; set; }
        [Required]
        public Guid ShipId { get; set; }
        [Required]
        public int PaymentMethod {  get; set; }
        [Required]
        public string Loaction { get; set; }
        [Required]
        public string ReceiverName { get; set; }
        [Required]
        public string ReceiverPhone { get; set; }
        [Required]
        public bool IsFastBuy { get; set; } = false;
    }

    public class ProductItem
    {
        public Guid productId { get; set; }
        public int size { get; set; }
        public int quantity { get; set; }
    }
}
