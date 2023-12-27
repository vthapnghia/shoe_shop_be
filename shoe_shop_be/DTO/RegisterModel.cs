using System.ComponentModel.DataAnnotations;

namespace shoe_shop_be.DTO
{
    public class RegisterModel
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string PasswordRepeat { get; set; }
    }
}
