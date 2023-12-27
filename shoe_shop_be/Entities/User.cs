using shoe_shop_be.Helpers;

namespace shoe_shop_be.Entities
{
    public class User
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Accounts Accounts { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Age { get; set; }
        public Gender Gender { get; set; }
        public string Address { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Avatar { get; set; } = string.Empty;
    }
}
