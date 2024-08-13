using Microsoft.AspNetCore.Components;
using RestaurantReviewsShared.Entities;
using RestaurantReviewsUI.Services;

namespace RestaurantReviewsUI.Components.Pages
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/aspnet/core/blazor/forms/validation?view=aspnetcore-8.0
    /// The DataAnnotationsValidator component attaches data annotations validation to a cascaded EditContext.
    /// 1. Field validation is performed when the user tabs out of a field. During field validation, 
    /// the DataAnnotationsValidator component associates all reported validation results with the field.
    /// 2. Model validation is performed when the user submits the form. During model validation, 
    /// the DataAnnotationsValidator component attempts to determine the field based on the member name that 
    /// the validation result reports. Validation results that aren't associated with an individual member are 
    /// associated with the model rather than a field.
    /// https://learn.microsoft.com/en-us/aspnet/core/blazor/forms/input-components?view=aspnetcore-8.0#example-form
    /// </summary>
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



        #endregion


        protected void NavigateToRestaurantDetail()
        {           
            Navigation!.NavigateTo($"restdetail/{SelectedRestaurant!.Id}/{SelectedRestaurant!.City}");
        }
    }
}
