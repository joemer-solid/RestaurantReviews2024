using Microsoft.AspNetCore.Mvc;
using RestaurantReviews2024.PortServices;
using RestaurantReviewsShared.Entities;
using System;
using System.Threading.Tasks;

namespace RestaurantReviews2024.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserReviewController : Controller
	{
		private readonly IRestaurantPortService _restaurantPortService;

		public UserReviewController(IRestaurantPortService restaurantPortService)
			=> _restaurantPortService = restaurantPortService ?? throw new ArgumentNullException(nameof(restaurantPortService));

		[HttpPost(Name = "AddReview")]
		public async Task<ActionResult> Create([FromBody] UserReviewVM userReviewDM)
		{
			await _restaurantPortService.PostRestaurantReview(userReviewDM!);
			return Ok();
		}
	}
}
