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
        public async Task<ProductDto> CreateProduct(ProductModel productModel, string accountId)
        {
            var account = await _accountRepository.GetById(Guid.Parse(accountId));
            if( account.IsSeller == false) {
                throw new ApiException(401, "Unauthorized!!", "");
            }
            if(productModel.listImage.Count() == 0)
            {
                throw new ApiException(400, "Error", "");
            }
            Product product = new Product();
            product.Name = productModel.Name;
            product.Price = productModel.Price;
            product.Type = productModel.Type;
            product.BrandId = Guid.Parse(productModel.BrandId);
            product.Description = productModel.Description;
            product.Gender = productModel.Gender;
            product.Discount = productModel.Discount;
            await _productRepository.Insert(product);
            List<string> listImage = new List<string>();
            foreach(var file in productModel.listImage)
            {
                var result = await _photoService.AddPhotoAsync(file);
                if(result.Error != null)
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

        public async Task<bool> DeletProduct(string productId, string accountId)
        {
            var account = await _accountRepository.GetById(Guid.Parse(accountId));
            if (account.IsSeller == false)
            {
                throw new ApiException(401, "Unauthorized!!", "");
            }
            var product = await _productRepository.GetById(productId);
            if(product == null)
            {
                throw new ApiException(400, "Product is not exist", "");
            }
            _productRepository.Delete(product);
            await _productRepository.SaveChange();
            return true;
        }

        public async Task<List<ProductDto>> GetAllProducts()
        {
            var listProduct = await _productRepository.GetAll();
            var listProductDto = _mapper.Map<List<ProductDto>>(listProduct);
            foreach (var product in listProductDto)
            {
                var listImage = await _imageRepository.GetAllByProduct(product.Id);
                foreach (var image in listImage)
                {
                    product.listImage.Add(image.Url);
                }
            }
            return listProductDto;
        }

        public async Task<ProductDto> GetProduct(string productId)
        {
            var product = await _productRepository.GetById(Guid.Parse(productId));
            if(product == null)
            {
                throw new ApiException(400, "Product is not exist", "");
            }
            var productDto = _mapper.Map<ProductDto>(product);
            var listImage = await _imageRepository.GetAllByProduct(Guid.Parse(productId));
            foreach (var image in listImage)
            {
                productDto.listImage.Add(image.Url);
            }
            return productDto;
        }

        public async Task<List<ProductDto>> SearchProduct(string search)
        {
            var searchProduct = await _productRepository.GetBySearch(search);
            var listProductDto = _mapper.Map<List<ProductDto>>(searchProduct);
            return listProductDto;
        }

        public async Task<ProductDto> UpdateProduct(string productId, ProductModel productModel, string accountId)
        {
            var account = await _accountRepository.GetById(Guid.Parse(accountId));
            if (account.IsSeller == false)
            {
                throw new ApiException(401, "Unauthorized!!", "");
            }
            var product = await _productRepository.GetById(Guid.Parse(productId));
            if(product == null)
            {
                throw new ApiException(400, "Product is not exist", "");
            }
            List<string> listImage = new List<string>();
            if (productModel.listImage.Count() > 0)
            {
                var imageProduct = await _imageRepository.GetAllByProduct(product.Id);
                foreach(var image  in imageProduct)
                {
                    _imageRepository.Delete(image);
                }
                foreach (var image in productModel.listImage)
                {
                    var result = await _photoService.AddPhotoAsync(image);
                    if(result.Error != null)
                    {
                        throw new ApiException(500, "Image upload fail", "");
                    }
                    Images images = new Images();
                    images.ProductId = product.Id;
                    images.Url = result.SecureUrl.AbsoluteUri;
                    await _imageRepository.Insert(images);
                    listImage.Add(result.SecureUrl.AbsoluteUri);
                }
            }
            product.Name = productModel.Name;
            product.Price = productModel.Price;
            product.Type = productModel.Type;
            product.BrandId = Guid.Parse(productModel.BrandId);
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
