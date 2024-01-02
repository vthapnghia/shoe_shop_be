namespace shoe_shop_be.Entities
{
    public class Images
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Url { get; set; }
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
    }
}
