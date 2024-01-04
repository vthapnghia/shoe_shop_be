using System.ComponentModel.DataAnnotations;

namespace shoe_shop_be.Entities
{
    public class Ratings
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
        public List<RatingImages> Images { get; set; }
        public string Comment { get; set; }
        [Range(1, 5)]
        public int Rate { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
