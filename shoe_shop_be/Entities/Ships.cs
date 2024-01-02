namespace shoe_shop_be.Entities
{
    public class Ships
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Type { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public List<Orders> Orders { get; set; }
    }
}
