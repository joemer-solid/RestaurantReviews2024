using RestaurantReviews2024.DataAdapters;
using RestaurantReviewService.Entities;
using RestaurantReviewsService.DomainModels;
using RestaurantReviewsService.ModelBuilders;
using RestaurantReviewsService.ModelBuilders.DomainModelBuilders;
using RestaurantReviewsService.ModelBuilders.ViewModelBuilders;
using RestaurantReviewsShared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantReviews2024.PortServices
{
    public class RestaurantService : IRestaurantPortService
	{
		private readonly IRestaurantsDataAdapter _restaurantDataAdapter;
        private readonly IUserReviewsDataAdapter _userReviewsDataAdapter;

		public RestaurantService(IRestaurantsDataAdapter restaurantDataAdapter, IUserReviewsDataAdapter userReviewsDataAdapter)
		{
			_restaurantDataAdapter = restaurantDataAdapter ?? throw new ArgumentNullException(nameof(restaurantDataAdapter));
			_userReviewsDataAdapter = userReviewsDataAdapter ?? throw new ArgumentNullException(nameof(userReviewsDataAdapter));
		}

		async Task IRestaurantPortService.AddRestaurant(RestaurantVM restaurantViewModel)
		{
            IModelBuilder<RestaurantDM, RestaurantVM> restaurantDomainModelBuilder =
               new RestaurantDomainModelBuilder();

            await _restaurantDataAdapter.AddNewRestaurant(restaurantDomainModelBuilder.Build(restaurantViewModel));
        }

		async Task<IList<RestaurantVM>> IRestaurantPortService.GetAllRestaurants()
		{
			IList<RestaurantVM> results = new List<RestaurantVM>();

			IList<RestaurantDM> restaurantDomainModelsList = await _restaurantDataAdapter.GetAllRestaurants();

			if (restaurantDomainModelsList != null)
			{
				IModelBuilder<RestaurantVM, RestaurantVMBuilderParams> restaurantViewModelBuilder = new RestaurantViewModelBuilder();

				foreach (RestaurantDM restaurantDM in restaurantDomainModelsList)
				{
					results.Add(restaurantViewModelBuilder.Build(new RestaurantVMBuilderParams
					{
						RestaurantDomainModel = restaurantDM						
					}));
				}
			}

			return results;
		}

		async Task<IList<RestaurantVM>> IRestaurantPortService.GetRestaurantById(int id)
		{
			IList<RestaurantVM> results = new List<RestaurantVM>();

			IList<RestaurantDM> restaurantDomainModelsList = await _restaurantDataAdapter.GetAllRestaurants();

			if (restaurantDomainModelsList != null)
			{
				var selectedRestaurant = restaurantDomainModelsList.SingleOrDefault(rst => rst.Id ==  id);

				if(selectedRestaurant != null)
				{
					IModelBuilder<RestaurantVM, RestaurantVMBuilderParams> restaurantViewModelBuilder = new RestaurantViewModelBuilder();
					results.Add(restaurantViewModelBuilder.Build(new RestaurantVMBuilderParams
					{
						RestaurantDomainModel = selectedRestaurant
					}));
				}
			}

			return results;
		}

		async Task<IList<RestaurantVM>> IRestaurantPortService.GetRestaurantReviewsByCity(string cityName)
		{
            IList<RestaurantVM> results = new List<RestaurantVM>();

            IList<RestaurantDM> restaurantDomainModelsList = await _restaurantDataAdapter.GetRestaurantsByCity(cityName);

            if (restaurantDomainModelsList != null)
            {
                IModelBuilder<RestaurantVM, RestaurantVMBuilderParams> restaurantViewModelBuilder = new RestaurantViewModelBuilder();

                foreach (RestaurantDM restaurantDM in restaurantDomainModelsList)
                {
                    IList<UserReviewDM> usersReviewsDomainModelList = await _userReviewsDataAdapter.GetUserReviewsForRestaurant(restaurantDM);

                    //foreach (UserReviewDM userReviewDM in usersReviewsDomainModelList)
                    //{
                    //    userReviewDM.User = await _usersDataAdapter.GetUserById(userReviewDM.UserIdRef);
                    //}

                    results.Add(restaurantViewModelBuilder.Build(new RestaurantVMBuilderParams
                    {
                        UserReviewsDMItems = usersReviewsDomainModelList,
                        RestaurantDomainModel = restaurantDM
                    }));
                }
            }

            return results;
        }

		async Task IRestaurantPortService.PostRestaurantReview(UserReviewVM userReviewViewModel)
		{
			IModelBuilder<UserReviewDM, UserReviewVM> userReviewDomainModelBuilder =
				new UserReviewDomainModelBuilder();

			_ = await _userReviewsDataAdapter.AddNewUserReview(userReviewDomainModelBuilder.Build(userReviewViewModel));
		}
	}
}
