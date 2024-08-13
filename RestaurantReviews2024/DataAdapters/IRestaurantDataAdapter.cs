using RestaurantReviewsService.DomainModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestaurantReviews2024.DataAdapters
{
	public interface IRestaurantsDataAdapter
	{
		Task<IList<RestaurantDM>> GetAllRestaurants();

		Task<IList<RestaurantDM>> GetRestaurantsByCity(string cityName);

		Task<int> AddNewRestaurant(RestaurantDM restaurant);
	}
}
