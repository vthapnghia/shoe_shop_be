using shoe_shop_be.DTO;
using shoe_shop_be.Errors;
using shoe_shop_be.Interfaces.IRepositories;
using shoe_shop_be.Interfaces.IServices;

namespace shoe_shop_be.Services
{
    public class RatingService : IRatingService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IRatingRepository _ratingRepository;
        private readonly IUserRepository _userRepository;

        public RatingService(IAccountRepository accountRepository, IRatingRepository ratingRepository, IUserRepository userRepository)
        {
            _accountRepository = accountRepository;
            _ratingRepository = ratingRepository;
            _userRepository = userRepository;
        }

        public Task<RatingDto> CreatRating(RatingModel ratingModel, Guid accountId)
        {
            throw new NotImplementedException();
        }
    }
}
