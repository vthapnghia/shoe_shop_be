namespace shoe_shop_be.Entities
{
    public class RatingImages
    {
        public Guid Id { get; set; }
        public string Url { get; set; }
        public Guid RatingId { get; set; }
        public Ratings Rating { get; set; }
    }
}
