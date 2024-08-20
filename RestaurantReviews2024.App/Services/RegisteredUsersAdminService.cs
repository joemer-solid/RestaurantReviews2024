using RestaurantReviewsShared.Identity;
using System.Net.Http.Json;

namespace RestaurantReviews2024.App.Services
{
    public class RegisteredUsersAdminService : ServiceBase, IRegisteredUsersAdminService
    {
        #region Fields

        private readonly string getAllRegisteredUsersUrl = @"api/testUser/all";
        private readonly TokenProvider _tokenProvider;

        #endregion

        #region CTOR

        public RegisteredUsersAdminService(HttpClient httpClient, TokenProvider tokenProvider) : base(httpClient)
            => _tokenProvider = tokenProvider ?? throw new ArgumentNullException(nameof(tokenProvider));

        #endregion

        #region IRegisteredUsersAdminService implementation

        async Task<IList<TestUser>> IRegisteredUsersAdminService.GetAllRegisteredUsersAsync()
            => await GetAllRegisteredUsers(HttpClient, getAllRegisteredUsersUrl, _tokenProvider);

        #endregion

        #region Private class methods

        private static async Task<List<TestUser>> GetAllRegisteredUsers(HttpClient httpClient, string url, TokenProvider tokenProvider)
        {
            List<TestUser> results = [];
            
            httpClient.DefaultRequestHeaders.Add("Cookie", $".AspNetCore.Cookies={tokenProvider.Cookie}");

            var registeredUsersResult = await httpClient.GetFromJsonAsync<List<TestUser>>(url);

            if (registeredUsersResult != null && registeredUsersResult.Count != 0)
            {
                results = registeredUsersResult;
            }

            return results;
        }

        #endregion

    }
}
