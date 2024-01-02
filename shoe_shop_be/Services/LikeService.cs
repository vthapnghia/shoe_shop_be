using AutoMapper;
using CloudinaryDotNet;
using shoe_shop_be.DTO;
using shoe_shop_be.Entities;
using shoe_shop_be.Errors;
using shoe_shop_be.Interfaces.IRepositories;
using shoe_shop_be.Interfaces.IServices;
using shoe_shop_be.Repositories;

namespace shoe_shop_be.Services
{
    public class LikeService : ILikeService
    {
        private readonly ILikeRepository _likeRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;

        public LikeService(ILikeRepository likeRepository, IAccountRepository accountRepository, IMapper mapper, IProductRepository productRepository)
        {
            _likeRepository = likeRepository;
            _accountRepository = accountRepository;
            _mapper = mapper;
            _productRepository = productRepository;
        }
        public async Task<LikeDto> AddToLikeList(LikeModel likeModel, string accountId)
        {
            var isUserLike = await _likeRepository.GetBYUserIdAndProductId(Guid.Parse(likeModel.ProductId), Guid.Parse(accountId));
            if (isUserLike != null)
            {
                throw new ApiException(400, "Product already in list", "");
            }
            Likes like = new Likes();
            like.ProductId = Guid.Parse(likeModel.ProductId);
            like.AccountId = Guid.Parse(accountId);
            await _likeRepository.Insert(like);
            await _likeRepository.SaveChange();
            var likeDto = _mapper.Map<LikeDto>(like);
            return likeDto;
        }

        public async Task<List<ProductDto>> GetLikeList(string accountId)
        {
            var listLike = await _likeRepository.GetByAccountId(Guid.Parse(accountId));
            if (listLike == null)
            {
                throw new ApiException(400, "User haven't like product", "");
            }
            List<Product> listProduct = new List<Product>();
            foreach( var item in listLike)
            {
                var product = await _productRepository.GetById(item.ProductId);
                listProduct.Add(product);
            }
            var listProductDto = _mapper.Map<List<ProductDto>>(listProduct);
            return listProductDto;
        }

        public async Task<bool> RemoveFromLikeList(string id, string accountId)
        {
            var isUserLike = await _likeRepository.GetBYUserIdAndProductId(Guid.Parse(id), Guid.Parse(accountId));
            if (isUserLike == null)
            {
                throw new ApiException(400, "Product haven't like product", "");
            }
            _likeRepository.Delete(isUserLike);
            await _likeRepository.SaveChange();
            return true;
        }
    }
}
