namespace shoe_shop_be.Entities
{
    public class DetailProduct
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
        public Guid ColorId { get; set; }
        public Colors? Color { get; set; }
        public Guid SizeId { get; set; }
        public Sizes? Size { get; set; }
    }
}
