using shoe_shop_be.DTO;

namespace shoe_shop_be.Interfaces.IServices
{
    public interface IProductService
    {
        Task<ProductDto> CreateProduct(ProductModel productModel, string accountId);
        Task<ProductDto> GetProduct(string productId);
        Task<List<ProductDto>> GetAllProducts();
        Task<ProductDto> UpdateProduct(string productId, ProductModel product, string accountId);
        Task<List<ProductDto>> SearchProduct(string search);
        Task<bool> DeletProduct(string productId, string accountId);
    }
}
