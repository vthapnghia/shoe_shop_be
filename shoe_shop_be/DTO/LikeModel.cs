using shoe_shop_be.Entities;
using System.ComponentModel.DataAnnotations;

namespace shoe_shop_be.DTO
{
    public class LikeModel
    {
        [Required]
        public Guid ProductId { get; set; }
    }
}
