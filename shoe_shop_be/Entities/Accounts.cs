using shoe_shop_be.Interfaces.EntityInterfaces;

namespace shoe_shop_be.Entities
{
    public class Accounts: ICreatedAt
    {
        public Guid Id { get; set; }
        public Guid? UserId { get; set; }
        public User? User { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public bool IsAdmin { get; set; } = false;
        public bool IsActive { get; set; } = false;
        public bool IsSeller { get; set; } = false;
        public DateTime? CreatedAt { get ; set; }
        public string? Secret { get; set; }
        public string? GoogleId { get; set; }
    }
}
