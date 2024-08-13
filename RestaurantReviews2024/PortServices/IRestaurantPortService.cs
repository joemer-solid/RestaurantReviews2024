using RestaurantReviewsShared.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestaurantReviews2024.PortServices
{
	public interface IRestaurantPortService
	{
		Task<IList<RestaurantVM>> GetAllRestaurants();

		Task<IList<RestaurantVM>> GetRestaurantById(int id);

		Task<IList<RestaurantVM>> GetRestaurantReviewsByCity(string cityName);

		Task PostRestaurantReview(UserReviewVM userReviewViewModel);

		Task AddRestaurant(RestaurantVM restaurantViewModel);
	}
}
