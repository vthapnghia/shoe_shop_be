using Microsoft.EntityFrameworkCore;
using shoe_shop_be.Entities;

namespace shoe_shop_be.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options) { }

        public DbSet<Accounts> Accounts { get; set; }
        public DbSet<Brands> Brands { get; set; }
        public DbSet<Colors> Colors { get; set; }
        public DbSet<DetailProduct> DetailProducts { get; set; }
        public DbSet<Images> Images { get; set; }
        public DbSet<Likes> Likes { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<OrderDetails> OrderDetails { set; get; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Promotions> Promotions { get; set; }
        public DbSet<RatingImages> RatingImages { get; set; }
        public DbSet<Ratings> Ratings { get; set; }
        public DbSet<Ships> Ships { get; set; }
        public DbSet<Sizes> Sizes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Cart> Carts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Colors>().HasData(
                new Colors() { Name = "red" },
                new Colors() { Name = "blue" },
                new Colors() { Name = "green" }
            );

            modelBuilder.Entity<Sizes>().HasData(
                new Sizes() { Name = "40" },
                new Sizes() { Name = "41" },
                new Sizes() { Name = "42" }
            );

            modelBuilder.Entity<Brands>().HasData(
                new Brands() { Name = "Addidas"},
                new Brands() { Name = "Nike" },
                new Brands() { Name = "Converse" }
            );
        }
    }
}
