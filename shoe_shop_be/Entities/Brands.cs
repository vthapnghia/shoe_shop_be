﻿namespace shoe_shop_be.Entities
{
    public class Brands
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public List<Product> Products { get; set; }
    }
}
