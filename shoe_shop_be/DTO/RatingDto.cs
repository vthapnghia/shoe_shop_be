using shoe_shop_be.Entities;
using System.ComponentModel.DataAnnotations;

namespace shoe_shop_be.DTO
{
    public class RatingDto
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public List<string> Images { get; set; } = new List<string>();
        public string Comment { get; set; }
        public int Rate { get; set; }
    }
}
