using Microsoft.AspNetCore.Components;
using RestaurantReviewsShared.Entities;
using RestaurantReviewsUI.Services;

namespace RestaurantReviewsUI.Components.Pages
{
    public partial class RestDetail : ComponentBase
    {
        [Parameter]
        public int Id { get; set; }

        [Parameter]
        public string? City { get; set; }

        [Inject]
        NavigationManager Navigation { get; set; }

        [Inject]
        public IRestaurantsListService? RestaurantListService { get; set; }

        protected RestaurantVM? SelectedRestaurant { get; private set; }

        protected bool HasUserReviews { get => SelectedRestaurant != null && SelectedRestaurant.UserReviews != null && SelectedRestaurant.UserReviews.Count > 0; }


        protected override async Task OnInitializedAsync()
        {
            var resultsContainer = await RestaurantListService?.GetRestaurantWithReviewsAsync(Id!, City!)!;

            if(resultsContainer != null && resultsContainer.Count > 0) 
            { 
                SelectedRestaurant = resultsContainer[0];
            }           
        }

        protected void NavigateToRestaurantList()
        {
            Navigation.NavigateTo("/restaurantlist");
        }
    }
}
