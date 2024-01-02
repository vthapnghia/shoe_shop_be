using shoe_shop_be.Entities;

namespace shoe_shop_be.DTO
{
    public class LikeDto
    {
        public Guid Id { get; set; }
        public Guid AccountId { get; set; }
        public Guid ProductId { get; set; }
    }
}
