using RestaurantReviewsShared.Entities;

namespace RestaurantReviews2024.App.Services
{
    public interface IRestaurantsListService
    {
        Task<IList<RestaurantVM>> GetAllRestaurantsAsync();

        Task<IList<RestaurantVM>> GetRestaurantWithReviewsAsync(int id, string city);

        Task<IList<RestaurantVM>> GetRestuarantByIdAsync(int id);
    }
}
