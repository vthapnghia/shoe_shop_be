namespace shoe_shop_be.DTO
{
    public class LoginResponseModel
    {
        public string Token { get; set; }
        public UserModel User { get; set; }
        public bool IsAdmin { get; set; } = false;
        public bool IsSeller { get; set; } = false;
    }
}
