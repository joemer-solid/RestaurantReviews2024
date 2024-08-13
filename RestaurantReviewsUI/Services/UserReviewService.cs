using RestaurantReviewsShared.Entities;

namespace RestaurantReviewsUI.Services
{
    public class UserReviewService : ServiceBase, IUserReviewService
    {        
        private readonly string createUserReviewUrl = @"api/UserReview";

        #region CTOR
        public UserReviewService(HttpClient client) : base(client) { }
        #endregion

        async Task IUserReviewService.CreateUserReview(UserReviewVM userReviewVM)
            => await PostUserReview(HttpClient, userReviewVM, createUserReviewUrl!);       

        private static async Task PostUserReview(HttpClient httpClient, UserReviewVM userReviewVM, string createUserReviewUrl)
        {
            await httpClient.PostAsJsonAsync(createUserReviewUrl, userReviewVM);            
        }
    }
}
