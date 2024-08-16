using Microsoft.AspNetCore.Components;
using RestaurantReviews2024.App.Services;
using RestaurantReviewsShared.Entities;

namespace RestaurantReviews2024.App.Pages
{
    public partial class AddReview
    {
        #region Properties

        public required UserReviewVM UserReviewViewModel { get; set; }

        public RestaurantVM? SelectedRestaurant { get; set; }

        protected string RestaurantName { get => SelectedRestaurant != null ? SelectedRestaurant.Name! : string.Empty; }

        [Parameter]
        public int Id { get; set; }

        [Inject]
        public IRestaurantsListService? RestaurantListService { get; set; }

        [Inject]
        public IUserReviewService? UserReviewService { get; set; }

        [Inject]
        NavigationManager Navigation { get; set; }

        #endregion

        #region Methods

        protected override async Task OnInitializedAsync()
        {
            UserReviewViewModel = new UserReviewVM();
            var resultsContainer = await RestaurantListService?.GetRestuarantByIdAsync(Id!)!;

            if (resultsContainer != null && resultsContainer.Count > 0)
            {
                SelectedRestaurant = resultsContainer[0];
                UserReviewViewModel.RestaurantIdRef = SelectedRestaurant.Id;
            }
        }

        #endregion

        #region Event Handlers

        protected async Task HandleValidSubmit()
        {
            UserReviewViewModel.RatingsRef = UserReviewViewModel.RatingsLevel;
            await UserReviewService?.CreateUserReview(UserReviewViewModel)!;
        }

        protected void NavigateToRestaurantDetail()
        {
            Navigation!.NavigateTo($"restdetail/{SelectedRestaurant!.Id}/{SelectedRestaurant!.City}");
        }

        #endregion


    }
}
