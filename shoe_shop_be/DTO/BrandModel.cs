using System.ComponentModel.DataAnnotations;

namespace shoe_shop_be.DTO
{
    public class BrandModel
    {
        [Required]
        public string Name { get; set; }
    }
}
