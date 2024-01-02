using System.ComponentModel.DataAnnotations;

namespace shoe_shop_be.DTO
{
    public class BrandDto
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
