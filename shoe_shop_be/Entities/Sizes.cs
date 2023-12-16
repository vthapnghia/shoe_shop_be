namespace shoe_shop_be.Entities
{
    public class Sizes
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public List<DetailProduct> DetailProducts { get; set; } = new List<DetailProduct>();
    }
}
