using RestaurantReviewsShared.Entities;

namespace RestaurantReviewsUI.Services
{
    public interface IUserReviewService
    {
        Task CreateUserReview(UserReviewVM userReviewVM);
    }
}
