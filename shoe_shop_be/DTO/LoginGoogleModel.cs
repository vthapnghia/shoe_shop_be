using System.ComponentModel.DataAnnotations;

namespace shoe_shop_be.DTO
{
    public class LoginGoogleModel
    {
        [Required]
        public string GoogleId { get; set; }
    }
}
