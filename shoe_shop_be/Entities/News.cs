using shoe_shop_be.Interfaces.EntityInterfaces;

namespace shoe_shop_be.Entities
{
    public class News: ICreatedAt
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
        public string Thumbnail { get; set; }
        public string Title { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
