using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using RestaurantReviews2024.App.Services;
using RestaurantReviewsShared.Entities;

namespace RestaurantReviews2024.App.Pages
{
    public partial class RestDetail
    {
        [Parameter]
        public int Id { get; set; }

        [Parameter]
        public string? City { get; set; }

        [Inject]
        NavigationManager Navigation { get; set; }

        [Inject]
        public IRestaurantsListService? RestaurantListService { get; set; }

        [CascadingParameter]
        protected Task<AuthenticationState>? AuthenticationStateTask { get; set; }

        protected RestaurantVM? SelectedRestaurant { get; private set; }

        protected bool IsAuthorizedToAddReview { get; private set; }

        protected bool HasUserReviews { get => SelectedRestaurant != null && SelectedRestaurant.UserReviews != null && SelectedRestaurant.UserReviews.Count > 0; }


        protected override async Task OnInitializedAsync()
        {
            var resultsContainer = await RestaurantListService?.GetRestaurantWithReviewsAsync(Id!, City!)!;

            if (resultsContainer != null && resultsContainer.Count > 0)
            {
                SelectedRestaurant = resultsContainer[0];
                IsAuthorizedToAddReview = await GetIsAuthorizedToAddReview(AuthenticationStateTask!);
            }
        }

        protected void NavigateToRestaurantList()
        {
            Navigation.NavigateTo("/restaurantlist");
        }

        private static async Task<bool> GetIsAuthorizedToAddReview(Task<AuthenticationState> authenticationStateTask)
        {
            bool isAuthorized = false;
            var authenticationResult = await authenticationStateTask;
            if (authenticationResult != null)
            {
                isAuthorized = authenticationResult.User!.Identity!.Name!.Equals("Jamie", StringComparison.CurrentCultureIgnoreCase);
            }

            return isAuthorized;
        }
    }
}
