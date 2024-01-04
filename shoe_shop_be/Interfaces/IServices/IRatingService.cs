using shoe_shop_be.DTO;

namespace shoe_shop_be.Interfaces.IServices
{
    public interface IRatingService
    {
        Task<RatingDto> CreatRating(RatingModel ratingModel, Guid accountId);
    }
}
