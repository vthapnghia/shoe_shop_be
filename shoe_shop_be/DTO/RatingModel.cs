using shoe_shop_be.Entities;
using System.ComponentModel.DataAnnotations;

namespace shoe_shop_be.DTO
{
    public class RatingModel
    {
        [Required]
        public Guid ProductId { get; set; }
        [Required]
        public List<IFormFile> Images { get; set; }
        [Required]
        public string Comment { get; set; }
        [Required]
        [Range(1, 5)]
        public int Rate { get; set; }
        [Required]
        public Guid OrderDetailId { get; set; }
    }
}
