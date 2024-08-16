using RestaurantReviewsShared.Entities;

namespace RestaurantReviews2024.App.Services
{
    public interface IUserReviewService
    {
        Task CreateUserReview(UserReviewVM userReviewVM);
    }
}
