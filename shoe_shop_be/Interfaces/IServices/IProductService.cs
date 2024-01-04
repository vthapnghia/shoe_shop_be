using shoe_shop_be.DTO;

namespace shoe_shop_be.Interfaces.IServices
{
    public interface IProductService
    {
        Task<ProductDto> CreateProduct(ProductModel productModel, Guid accountId);
        Task<ProductDto> GetProduct(Guid productId);
        Task<List<ProductDto>> GetAllProducts();
        Task<ProductDto> UpdateProduct(Guid productId, ProductModel product, Guid accountId);
        Task<List<ProductDto>> SearchProduct(string search);
        Task<bool> DeletProduct(Guid productId, Guid accountId);
    }
}
