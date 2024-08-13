using RestaurantReviewService.Entities;
using RestaurantReviewService.Operations;
using RestaurantReviewsService.DomainModels;
using RestaurantReviewsService.ModelBuilders.DomainModelBuilders;
using RestaurantReviewsService.ModelBuilders;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using RestaurantReviewsService.ModelBuilders.DataEntityModelBuilders;

namespace RestaurantReviews2024.DataAdapters
{
	public class RestaurantDataAdapter : IRestaurantsDataAdapter
	{
		async Task<int> IRestaurantsDataAdapter.AddNewRestaurant(RestaurantDM restaurant)
		{
            IModelBuilder<Restaurant, RestaurantDM> domainToEntityModelBuilder = new RestaurantDomainEntityModelBuilder();
            AddNewRestaurantOperation addNewRestaurantOperation = new AddNewRestaurantOperation();

            Restaurant restaurantDataEntity = domainToEntityModelBuilder.Build(restaurant);

			await Task.CompletedTask;

            return addNewRestaurantOperation.AddNewRestaurant(restaurantDataEntity);
        }

		async Task<IList<RestaurantDM>> IRestaurantsDataAdapter.GetAllRestaurants()
		{
			IModelBuilder<RestaurantDM, Restaurant> modelBuilder = new RestaurantDomainModelBuilder();
			SelectAllRestaurantsOperation selectAllRestaurantsOperaton = new SelectAllRestaurantsOperation();
			IList<RestaurantDM> results = new List<RestaurantDM>();

			IList<Restaurant> operationResults = selectAllRestaurantsOperaton.SelectAll();

			if (operationResults != null && operationResults.Count > 0)
			{
				foreach (Restaurant restaurant in operationResults)
				{
					results.Add(modelBuilder.Build(restaurant));
				}
			}

			return await Task.FromResult(results);
		}

		async Task<IList<RestaurantDM>> IRestaurantsDataAdapter.GetRestaurantsByCity(string cityName)
		{
            IList<RestaurantDM> results = new List<RestaurantDM>();

			IList<RestaurantDM> allRestaurantResults = await ((IRestaurantsDataAdapter)this).GetAllRestaurants();

			if(allRestaurantResults != null)
			{
				var filteredResults = allRestaurantResults?
					.Where(r => r.City.Equals(cityName, System.StringComparison.OrdinalIgnoreCase)).ToList<RestaurantDM>();

                if (filteredResults != null && filteredResults.Count > 0)
                {
					results = filteredResults;
				}
            }

            return results;
        }		
	}
}
