using shoe_shop_be.DTO;

namespace shoe_shop_be.Interfaces.IServices
{
    public interface IBrandService
    {
        Task<IEnumerable<BrandDto>> GetAllBrand();
        Task<BrandDto> CreateBrand(BrandModel brand, string sellerId);
        Task<BrandDto> UpdateBrand(BrandModel brandModel, string brandId, string sellerId);
        Task DeleteBrand(string brandId, string sellerId);
        Task<BrandDto> GetBrand(string id);
    }
}
