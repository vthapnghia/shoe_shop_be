using shoe_shop_be.Entities;

namespace shoe_shop_be.DTO
{
    public class AccountsDto
    {
        public Guid? UserId { get; set; }
        public string Email { get; set; }
        public bool IsAdmin { get; set; } = false;
        public bool IsActive { get; set; } = false;
        public bool IsSeller { get; set; } = false;
        public string? GoogleId { get; set; }
    }
}
