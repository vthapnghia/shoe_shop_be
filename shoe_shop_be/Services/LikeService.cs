using AutoMapper;
using CloudinaryDotNet;
using shoe_shop_be.Data;
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
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;
        private readonly DataContext _dataContext;

        public LikeService(ILikeRepository likeRepository, IMapper mapper, IProductRepository productRepository, DataContext dataContext)
        {
            _likeRepository = likeRepository;
            _mapper = mapper;
            _productRepository = productRepository;
            _dataContext = dataContext;
        }
        public async Task<LikeDto> AddToLikeList(LikeModel likeModel, Guid accountId)
        {
            var isUserLike = await _likeRepository.GetBYUserIdAndProductId(likeModel.ProductId, accountId);
            //var isUserLike = _dataContext.Set<Likes>().AsQueryable().Where(l => l.AccountId == accountId && l.ProductId == likeModel.ProductId);
            if (isUserLike != null && isUserLike.Delete == true)
            {
                isUserLike.Delete = false;
                _likeRepository.Update(isUserLike);
                await _likeRepository.SaveChange();
                return _mapper.Map<LikeDto>(isUserLike);
            }
            Likes like = new Likes();
            like.ProductId = likeModel.ProductId;
            like.AccountId = accountId;
            await _likeRepository.Insert(like);
            await _likeRepository.SaveChange();
            return _mapper.Map<LikeDto>(like);
        }

        public async Task<List<ProductDto>> GetLikeList(Guid accountId)
        {
            var listLike = await _likeRepository.GetByAccountId(accountId);
            if (listLike == null)
            {
                throw new ApiException(400, "User haven't like product", "");
            }
            List<ProductDto> listProductDto = new List<ProductDto>();
            foreach (var like in listLike)
            {
                var productDto = _mapper.Map<ProductDto>(like.Product);
                foreach (var image in like.Product.ProductImages)
                {
                    productDto.listImage.Add(image.Url);
                }
                listProductDto.Add(productDto);
            }
            return listProductDto;
        }

        public async Task<bool> RemoveFromLikeList(Guid id, Guid accountId)
        {
            var isUserLike = await _likeRepository.GetBYUserIdAndProductId(id, accountId);
            if (isUserLike == null|| isUserLike.Delete == true)
            {
                throw new ApiException(400, "User havent like product", "");
            }
            isUserLike.Delete = true;
            _likeRepository.Update(isUserLike);
            await _likeRepository.SaveChange();
            return true;
        }
    }
}
