using System.ComponentModel.DataAnnotations;

namespace shoe_shop_be.DTO
{
    public class CartModel
    {
        [Required]
        public Guid ProductId { get; set; }
        [Required]
        public Guid AccountId { get; set; }
        [Required]
        public int Quatity { get; set; }
        [Required]
        public int Size { get; set; }
    }
}
