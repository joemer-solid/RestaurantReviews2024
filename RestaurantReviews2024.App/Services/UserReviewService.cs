using RestaurantReviewsShared.Entities;
using System.Net.Http.Json;

namespace RestaurantReviews2024.App.Services
{
    public class UserReviewService : ServiceBase, IUserReviewService
    {
        private readonly string createUserReviewUrl = @"api/UserReview";

        #region CTOR
        public UserReviewService(HttpClient client) : base(client) { }
        #endregion

        #region IUserReviewService implementation

        async Task IUserReviewService.CreateUserReview(UserReviewVM userReviewVM)
            => await PostUserReview(HttpClient, userReviewVM, createUserReviewUrl!);

        #endregion

        #region Private class methods

        private static async Task PostUserReview(HttpClient httpClient, UserReviewVM userReviewVM, string createUserReviewUrl)
        {
            await httpClient.PostAsJsonAsync(createUserReviewUrl, userReviewVM);
        }

        #endregion
    }
}
