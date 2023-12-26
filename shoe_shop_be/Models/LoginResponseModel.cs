using shoe_shop_be.DTO;

namespace shoe_shop_be.Models
{
    public class LoginResponseModel
    {
        public string Token {  get; set; }
        public UserDto User { get; set; }
        public bool IsAdmin { get; set; } = false;
        public bool IsSeller { get; set; } = false;
    }
}
