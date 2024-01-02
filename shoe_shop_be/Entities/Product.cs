using shoe_shop_be.Helpers;
using shoe_shop_be.Interfaces.EntityInterfaces;

namespace shoe_shop_be.Entities
{
    public class Product: ICreatedAt
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public int Price { get; set; }
        public ProductType Type { get; set; }
        public Guid BrandId { get; set; }
        public Brands Brand { get; set; }
        public string Description { get; set; }
        public Gender Gender { get; set; }
        public bool IsActive { get; set; } = true;
        public int Discount { get; set; }
        public DateTime? CreatedAt { get ; set; }
        public List<Images> ProductImages { get; set; } = new List<Images>();
        public List<Likes> Likes { set; get; } = new List<Likes>();
        public List<DetailProduct> DetailProducts { get; set; } = new List<DetailProduct>();
        public List<Ratings> Ratings { get; set; } = new List<Ratings>();
    }
}
