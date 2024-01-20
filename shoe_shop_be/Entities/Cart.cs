namespace shoe_shop_be.Entities
{
    public class Cart
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid AccountId { get; set; }
        public Accounts Account { get; set; }
        public List<CartItem> CartItems { get; set; } = new List<CartItem>();
    }
}
