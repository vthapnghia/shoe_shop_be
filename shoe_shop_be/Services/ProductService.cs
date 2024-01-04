using AutoMapper;
using shoe_shop_be.DTO;
using shoe_shop_be.Entities;
using shoe_shop_be.Errors;
using shoe_shop_be.Interfaces.IRepositories;
using shoe_shop_be.Interfaces.IServices;
using shoe_shop_be.Repositories;

namespace shoe_shop_be.Services
{
    public class ProductService : IProductService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IProductRepository _productRepository;
        private readonly IPhotoService _photoService;
        private readonly IMapper _mapper;
        private readonly IImageRepository _imageRepository;

        public ProductService(
            IAccountRepository accountRepository,
            IProductRepository productRepository,
            IPhotoService photoService,
            IMapper mapper,
            IImageRepository imageRepository)
        {
            _accountRepository = accountRepository;
            _productRepository = productRepository;
            _photoService = photoService;
            _mapper = mapper;
            _imageRepository = imageRepository;
        }
        public async Task<ProductDto> CreateProduct(ProductModel productModel, Guid accountId)
        {
            var account = await _accountRepository.GetById(accountId);
            if (account.IsSeller == false)
            {
                throw new ApiException(401, "Unauthorized!!", "");
            }
            if (productModel.listImage.Count() == 0)
            {
                throw new ApiException(400, "Error", "");
            }
            var product = _mapper.Map<Product>(productModel);
            await _productRepository.Insert(product);
            List<string> listImage = new List<string>();
            foreach (var file in productModel.listImage)
            {
                var result = await _photoService.AddPhotoAsync(file);
                if (result.Error != null)
                {
                    throw new ApiException(500, result.Error.Message, "");
                }
                listImage.Add(result.SecureUrl.AbsoluteUri);
                Images images = new Images();
                images.ProductId = product.Id;
                images.Url = result.SecureUrl.AbsoluteUri;
                await _imageRepository.Insert(images);
            }
            await _productRepository.SaveChange();
            var productDto = _mapper.Map<ProductDto>(product);
            productDto.listImage = listImage;
            return productDto;
        }

        public async Task<bool> DeletProduct(Guid productId, Guid accountId)
        {
            var account = await _accountRepository.GetById(accountId);
            if (account.IsSeller == false)
            {
                throw new ApiException(401, "Unauthorized!!", "");
            }
            var product = await _productRepository.GetById(productId);
            if (product == null)
            {
                throw new ApiException(400, "Product is not exist", "");
            }
            _productRepository.Delete(product);
            await _productRepository.SaveChange();
            return true;
        }

        public async Task<List<ProductDto>> GetAllProducts()
        {
            var listProduct = await _productRepository.GetAllProduct();
            var listProductDto = new List<ProductDto>();
            foreach (var product in listProduct)
            {
                var productDto = _mapper.Map<ProductDto>(product);
                foreach (var image in product.ProductImages)
                {
                    productDto.listImage.Add(image.Url);
                }
                listProductDto.Add(productDto);
            }
            return listProductDto;
        }

        public async Task<ProductDto> GetProduct(Guid productId)
        {
            var product = await _productRepository.GetProductById(productId);
            if (product == null)
            {
                throw new ApiException(400, "Product is not exist", "");
            }
            var productDto = _mapper.Map<ProductDto>(product);
            foreach (var image in product.ProductImages)
            {
                productDto.listImage.Add(image.Url);
            }
            return productDto;
        }

        public async Task<List<ProductDto>> SearchProduct(string search)
        {
            var searchProduct = await _productRepository.GetBySearch(search);
            var listProductDto = new List<ProductDto>();
            foreach (var product in searchProduct)
            {
                var productDto = _mapper.Map<ProductDto>(product);
                foreach (var image in product.ProductImages)
                {
                    productDto.listImage.Add(image.Url);
                }
                listProductDto.Add(productDto);
            }
            return listProductDto;
        }

        public async Task<ProductDto> UpdateProduct(Guid productId, ProductModel productModel, Guid accountId)
        {
            var account = await _accountRepository.GetById(accountId);
            if (account.IsSeller == false)
            {
                throw new ApiException(401, "Unauthorized!!", "");
            }
            var product = await _productRepository.GetProductById(productId);
            if (product == null)
            {
                throw new ApiException(400, "Product is not exist", "");
            }

            foreach (var image in product.ProductImages)
            {
                _imageRepository.Delete(image);
            }
            List<string> listImage = new List<string>();
            foreach (var image in productModel.listImage)
            {
                var result = await _photoService.AddPhotoAsync(image);
                if (result.Error != null)
                {
                    throw new ApiException(500, "Image upload fail", "");
                }
                Images images = new Images();
                images.ProductId = product.Id;
                images.Url = result.SecureUrl.AbsoluteUri;
                await _imageRepository.Insert(images);
                listImage.Add(result.SecureUrl.AbsoluteUri);
            }

            product.Name = productModel.Name;
            product.Price = productModel.Price;
            product.Type = productModel.Type;
            product.BrandId = productModel.BrandId;
            product.Description = productModel.Description;
            product.Gender = productModel.Gender;
            product.Discount = productModel.Discount;
            _productRepository.Update(product);
            await _productRepository.SaveChange();
            var productDto = _mapper.Map<ProductDto>(product);
            productDto.listImage = listImage;
            return productDto;
        }


    }
}
