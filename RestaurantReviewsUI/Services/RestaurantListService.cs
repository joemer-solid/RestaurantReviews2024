using RestaurantReviewsShared.Entities;

namespace RestaurantReviewsUI.Services
{
	public class RestaurantListService : ServiceBase, IRestaurantsListService
	{
		#region Fields

		private readonly string getAllRestaurantsUrl = @"api/RestaurantReview/all";
        private readonly string getRestaurantReviewsForCityUrl = @"api/RestaurantReview/reviews";       
        private readonly string getRestaurantByIdUrl = @"api/RestaurantReview";

		#endregion

		#region CTOR
		public RestaurantListService(HttpClient client) : base(client) { }
		#endregion

		#region IRestaurantsListService implementations
		async Task<IList<RestaurantVM>> IRestaurantsListService.GetAllRestaurantsAsync()
			=> await GetAllRestaurants(HttpClient, getAllRestaurantsUrl);

		async Task<IList<RestaurantVM>> IRestaurantsListService.GetRestuarantByIdAsync(int id)
		    => await GetRestaurantById(HttpClient, getRestaurantByIdUrl, id);

		async Task<IList<RestaurantVM>> IRestaurantsListService.GetRestaurantWithReviewsAsync(int id, string city)
        {
            List<RestaurantVM> results = [];           

            var restaurantReviewsByCity = await GetRestaurantReviewsByCity(HttpClient, getRestaurantReviewsForCityUrl, city);
            if (restaurantReviewsByCity != null && restaurantReviewsByCity.Any())
            {
                RestaurantVM? selectedRestaurant =
                    (restaurantReviewsByCity).SingleOrDefault(x => x.Id == id);

                if (selectedRestaurant != null)
                {
                    results.Add(selectedRestaurant);
                }
            }

            return results;
        }

		#endregion

		#region Methods

		private static async Task<List<RestaurantVM>> GetRestaurantReviewsByCity(HttpClient httpClient, string url, string cityName)
        {
            List<RestaurantVM> results = [];          

            var restaurantAllResult = await httpClient.GetFromJsonAsync<List<RestaurantVM>>($"{url}?name={cityName}");

            if (restaurantAllResult != null && restaurantAllResult.Count != 0)
            {
                results = restaurantAllResult;
            }

            return results;
        }

        private static async Task<List<RestaurantVM>> GetRestaurantById(HttpClient httpClient, string url, int id)
        {
			List<RestaurantVM> results = [];

			var restaurantResult = await httpClient.GetFromJsonAsync<List<RestaurantVM>>($"{url}/{id}");

			if (restaurantResult != null && restaurantResult.Count == 1)
            {
                results.Add(restaurantResult.ElementAt(0));
            }

			return results;
		}

		private static async Task<List<RestaurantVM>> GetAllRestaurants(HttpClient httpClient, string url)
		{
            List<RestaurantVM> results = [];

            var restaurantAllResult = await httpClient.GetFromJsonAsync<List<RestaurantVM>>(url);

            if (restaurantAllResult != null && restaurantAllResult.Count != 0)
            {
                results = restaurantAllResult;
            }

            return results;
        }

        #endregion
    }  
}
