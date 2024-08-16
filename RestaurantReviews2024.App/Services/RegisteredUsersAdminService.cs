using RestaurantReviewsShared.Identity;
using System.Net.Http.Json;

namespace RestaurantReviews2024.App.Services
{
    public class RegisteredUsersAdminService : ServiceBase, IRegisteredUsersAdminService
    {
        #region Fields

        private readonly string getAllRegisteredUsersUrl = @"api/TestUser/all";

        #endregion

        #region CTOR

        public RegisteredUsersAdminService(HttpClient httpClient) : base(httpClient) { }

        #endregion

        #region IRegisteredUsersAdminService implementation

        async Task<IList<TestUser>> IRegisteredUsersAdminService.GetAllRegisteredUsersAsync()
            => await GetAllRegisteredUsers(HttpClient, getAllRegisteredUsersUrl);

        #endregion

        #region Private class methods

        private static async Task<List<TestUser>> GetAllRegisteredUsers(HttpClient httpClient, string url)
        {
            List<TestUser> results = [];

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
