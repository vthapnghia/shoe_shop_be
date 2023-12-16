namespace shoe_shop_be.Entities
{
    public class OrderDetails
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
        public Guid OrderId { get; set; }
        public Orders Order { get; set; }
        public int Quantity { get; set; }
        public int Size { get; set; }

    }
}
