using shoe_shop_be.Entities;

namespace shoe_shop_be.DTO
{
    public class CartDto
    {
        public Guid Id { get; set; }
        public Guid AccountId { get; set; }
        public List<CartItem> CartItems { get; set; } = new List<CartItem>();
    }
}
