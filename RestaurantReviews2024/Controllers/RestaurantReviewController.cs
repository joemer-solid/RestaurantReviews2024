using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantReviews2024.PortServices;
using RestaurantReviewsShared.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace RestaurantReviews2024.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class RestaurantReviewController : ControllerBase
	{
		private readonly IRestaurantPortService _restaurantPortService;

		public RestaurantReviewController(IRestaurantPortService restaurantPortService)
			=> _restaurantPortService = restaurantPortService ?? throw new ArgumentNullException(nameof(restaurantPortService));


		[HttpGet("all", Name = "GetAllRestaurants")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<ActionResult<List<RestaurantVM>>> GetAllRestaurants()
		{
			IList<RestaurantVM> result = new List<RestaurantVM>();

			if (_restaurantPortService != null)
			{
				 result = await _restaurantPortService.GetAllRestaurants();
			}
			return Ok(result!);
		} 
	
		[HttpGet("{id}", Name = "GetRestaurantById")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<ActionResult<List<RestaurantVM>>> GetRestaurant(int id)
		{
			IList<RestaurantVM> result = new List<RestaurantVM>();

			if (_restaurantPortService != null)
			{
				result = await _restaurantPortService.GetRestaurantById(id);
			}
			return Ok(result!);
		}

		[HttpGet("reviews", Name ="GetReviewsByCity")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        // example api/RetaurantReview/Twin Peaks/
        public async Task<ActionResult<IList<RestaurantVM>>> GetReviewsForCity(string name)
        {
			IList<RestaurantVM> result = new List<RestaurantVM>();

			if(_restaurantPortService != null)
			{
				result = await _restaurantPortService.GetRestaurantReviewsByCity(name);
            }

			return Ok(result!);
        }

        [HttpPost(Name = "AddRestaurant")]
        public void PostNewRestaurant([FromBody] RestaurantVM data)
        {
            _restaurantPortService.AddRestaurant(data);
        }
    }
}
