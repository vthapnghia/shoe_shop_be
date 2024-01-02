using AutoMapper;
using shoe_shop_be.DTO;
using shoe_shop_be.Entities;
using shoe_shop_be.Errors;
using shoe_shop_be.Interfaces.IRepositories;
using shoe_shop_be.Interfaces.IServices;

namespace shoe_shop_be.Services
{
    public class BrandService : IBrandService
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IMapper _mapper;
        private readonly IAccountRepository _accountRepository;
        public BrandService(IBrandRepository brandRepository, IMapper mapper, IAccountRepository accountRepository)
        {
            _brandRepository = brandRepository;
            _mapper = mapper;
            _accountRepository = accountRepository;
        }
        public async Task<BrandDto> CreateBrand(BrandModel brandModel, string sellerId)
        {
            var account = await _accountRepository.GetById(Guid.Parse(sellerId));
            if(account == null)
            {
                throw new ApiException(401, "Unauthenticate", "");
            }
            if(account.IsSeller == false)
            {
                throw new ApiException(401, "Unauthenticate", "");
            }
            Brands brand = new Brands();
            brand.Name = brandModel.Name;
            await _brandRepository.Insert(brand);
            await _brandRepository.SaveChange();
            var res = _mapper.Map<BrandDto>(brand);
            return res;
        }

        public async Task DeleteBrand(string brandId, string sellerId)
        {
            var account = await _accountRepository.GetById(Guid.Parse(sellerId));
            if (account == null)
            {
                throw new ApiException(401, "Unauthenticate", "");
            }
            if (account.IsSeller == false)
            {
                throw new ApiException(401, "Unauthenticate", "");
            }
            var brand = await _brandRepository.GetById(Guid.Parse(brandId));
            if (brand == null) {
                throw new ApiException(400, "Brand is not exist", "");
            }
            _brandRepository.Delete(brand);
            await _brandRepository.SaveChange();
        }

        public async Task<IEnumerable<BrandDto>> GetAllBrand()
        {
            var listBrand = await _brandRepository.GetAll();
            var listBrandDto = _mapper.Map<IEnumerable<BrandDto>>(listBrand);
            return listBrandDto;
        }

        public async Task<BrandDto> GetBrand(string id)
        {
            var brand = await _brandRepository.GetById(Guid.Parse(id));
            var brandDto = _mapper.Map<BrandDto>(brand);
            return brandDto;
        }

        public async Task<BrandDto> UpdateBrand(BrandModel brandModel, string brandId, string sellerId)
        {
            var account = await _accountRepository.GetById(Guid.Parse(sellerId));
            if (account == null)
            {
                throw new ApiException(401, "Unauthenticate", "");
            }
            if (account.IsSeller == false)
            {
                throw new ApiException(401, "Unauthenticate", "");
            }
            var brand = await _brandRepository.GetById(Guid.Parse(brandId));
            if (brand == null)
            {
                throw new ApiException(400, "Brand is not exist", "");
            }
            brand.Name = brandModel.Name;
            _brandRepository.Update(brand);
            await _brandRepository.SaveChange();
            return _mapper.Map<BrandDto>(brand);
        }
    }
}
