using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RestaurantReviews2024.DataAdapters;
using RestaurantReviews2024.PortServices;
using RestaurantReviews2024.Repository;
using System;

namespace RestaurantReviews2024
{
	public static class RestaurantReviewsAPIServiceRegistration
	{
		public static IServiceCollection ConfigureRestaurantReviewsAPIServices(this IServiceCollection services, IConfiguration configuration)
		{
			SetDatabaseTarget();
			
			services.AddScoped<IRestaurantPortService, RestaurantService>();
			services.AddScoped<IRestaurantsDataAdapter, RestaurantDataAdapter>();            
			services.AddScoped<IUserReviewsDataAdapter, UserReviewsDataAdapter>();

            return services;

		}

		private static void SetDatabaseTarget()
			=> Resources.SqlLiteDataBase = @$"{Environment.CurrentDirectory}/AppData/RestaurantReviews.db";			
	
	}
}
