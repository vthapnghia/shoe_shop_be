namespace shoe_shop_be.Entities
{
    public class Likes
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid AccountId { get; set; }
        public Accounts Account { get; set; }
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
    }
}
