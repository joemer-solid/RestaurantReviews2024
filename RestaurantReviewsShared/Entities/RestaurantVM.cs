using System.Collections;
using System.Collections.Generic;

namespace RestaurantReviewsShared.Entities
{
	public class RestaurantVM
	{
		public RestaurantVM()
		{
			UserReviews = new List<UserReviewVM>();
		}

		public int Id { get; set; }

		public string? Name { get; set; }

		public string? StreetAddress { get; set; }

		public string? City { get; set; }

		public string? State { get; set; }

		public int StateId { get; set; }

		public string? Overview { get; set; }

		public IList<UserReviewVM> UserReviews { get; set; }
	}
}
