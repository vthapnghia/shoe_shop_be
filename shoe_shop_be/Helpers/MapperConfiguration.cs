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
        }
    }
}
