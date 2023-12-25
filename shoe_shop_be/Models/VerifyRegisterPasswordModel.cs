using System.ComponentModel.DataAnnotations;

namespace shoe_shop_be.Models
{
    public class VerifyRegisterPasswordModel
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Secret {  get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string PasswordRepeat { get; set;}
    }
}
