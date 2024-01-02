using shoe_shop_be.Helpers;

namespace shoe_shop_be.DTO
{
    public class ProductDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public ProductType Type { get; set; }
        public Guid BrandId { get; set; }
        public string Description { get; set; }
        public Gender Gender { get; set; }
        public int Discount { get; set; }
        public List<string> listImage { get; set; } = new List<string>();
    }
}
