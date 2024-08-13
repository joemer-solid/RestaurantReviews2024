using RestaurantReviewsService.DomainModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestaurantReviews2024.DataAdapters
{
    public interface IUserReviewsDataAdapter
    {
        Task<IList<UserReviewDM>> GetUserReviewsForUser(UserDM userDm);

        Task<IList<UserReviewDM>> GetUserReviewsForRestaurant(RestaurantDM restaurantDm);

        Task<int> AddNewUserReview(UserReviewDM userReviewDM);

        Task<int> DeleteExistingUserReview(UserReviewDM userReviewDM);
    }
}
