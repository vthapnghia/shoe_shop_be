using AutoMapper;
using shoe_shop_be.DTO;
using shoe_shop_be.Entities;

namespace shoe_shop_be.Helpers
{
    public class MapperConfiguration: Profile
    {
        public MapperConfiguration()
        {
            CreateMap<Accounts, AccountsDto>();
            CreateMap<RegisterModel, Accounts>();
            CreateMap<User, UserModel>();
            CreateMap<Brands, BrandDto>();
            CreateMap<Product, ProductDto>();
            CreateMap<ProductModel, Product>();
            CreateMap<Ships, ShipDto>();
            CreateMap<Likes, LikeDto>();
            CreateMap<Cart, CartDto>();
            CreateMap<CartModel, Cart>();
            CreateMap<CartModel, CartItem>();
        }
    }
}
