using RestaurantReviewsShared.Entities;

namespace RestaurantReviewsUI.Services
{
	public interface IRestaurantsListService
	{
		Task<IList<RestaurantVM>> GetAllRestaurantsAsync();

		Task<IList<RestaurantVM>> GetRestaurantWithReviewsAsync(int id, string city);
		
		Task<IList<RestaurantVM>> GetRestuarantByIdAsync(int id);
	}
}
