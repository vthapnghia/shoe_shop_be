namespace shoe_shop_be.Entities
{
    public class Promotions
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public int MinOrder { get; set; }
        public int DiscountPrice { get; set; }
        public DateTime UseDateFrom { get; set; }
        public DateTime UseDateTo { get; set;}
        public int Amount { get; set; }
        public List<Orders> Orders { get; set; }
    }
}
