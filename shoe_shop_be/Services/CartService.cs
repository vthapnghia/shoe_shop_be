using AutoMapper;
using Microsoft.EntityFrameworkCore;
using shoe_shop_be.DTO;
using shoe_shop_be.Entities;
using shoe_shop_be.Errors;
using shoe_shop_be.Interfaces.IRepositories;
using shoe_shop_be.Interfaces.IServices;
using shoe_shop_be.Migrations;

namespace shoe_shop_be.Services
{
    public class CartService: ICartService
    {
        private readonly ICartRepository _cartRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly ICartItemRepository _cartItemRepository;
        private readonly IMapper _mapper;

        public CartService(ICartRepository cartRepository, IAccountRepository accountRepository, ICartItemRepository cartItemRepository, IMapper mapper)
        {
            _cartRepository = cartRepository;
            _accountRepository = accountRepository;
            _mapper = mapper;
            _cartItemRepository = cartItemRepository;
        }

        public async Task<Cart> AddToCart(CartModel cartModel, Guid accountId)
        {
            var account = await _accountRepository.GetById(accountId);

            if(account == null)
            {
                throw new ApiException(400, "Account is not exist", ""); 
            }
            var checkExist = await _cartRepository.Get().Where(q => q.AccountId == cartModel.AccountId).FirstOrDefaultAsync();
            if(checkExist != null) {
                if(checkExist != null && cartModel.Quatity == -1)
                {
                    _cartRepository.Delete(checkExist);
                    await _cartRepository.SaveChange();
                    return new Cart();
                }
                else
                {
                    var cartItem = await _cartItemRepository.Get().Where(c => c.CartId == checkExist.Id && c.ProductId == cartModel.ProductId).FirstOrDefaultAsync();
                    cartItem.Quatity = cartModel.Quatity;
                    _cartItemRepository.Update(cartItem);
                    await _cartRepository.SaveChange();
                    return checkExist;
                }
            }
            else
            {
                var cart = _mapper.Map<Cart>(cartModel);
                cart.AccountId = accountId;
                var cartItem = _mapper.Map<CartItem>(cartModel);
                cartItem.CartId = cart.Id;
                await _cartItemRepository.Insert(cartItem);
                await _cartRepository.Insert(cart);
                await _cartRepository.SaveChange();
                return cart;
            }
        }

        public Task<IList<CartDto>> GetAll(Guid accountId)
        {
            throw new NotImplementedException();
        }

        /*public async Task<IList<CartDto>> GetAll(Guid accountId)
        {
            var account = await _accountRepository.GetById(accountId);

            if (account == null)
            {
                throw new ApiException(400, "Account is not exist", "");
            }
            var cart = await _cartRepository.Get().Where(c => c.AccountId == accountId).Include(c => c.Product).ToListAsync();


        }*/
    }
}
