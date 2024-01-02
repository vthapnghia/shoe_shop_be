using System.ComponentModel.DataAnnotations;

namespace shoe_shop_be.DTO
{
    public class ShipModel
    {
        [Required]
        public string Type { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
