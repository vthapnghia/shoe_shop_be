using Microsoft.AspNetCore.Http;
using shoe_shop_be.Entities;
using shoe_shop_be.Helpers;
using System.ComponentModel.DataAnnotations;

namespace shoe_shop_be.DTO
{
    public class ProductModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public ProductType Type { get; set; }
        [Required]
        public Guid BrandId { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public Gender Gender { get; set; }
        [Required]
        public int Discount { get; set; }
        [Required]
        public IEnumerable<IFormFile> listImage {  get; set; }
    }
}
