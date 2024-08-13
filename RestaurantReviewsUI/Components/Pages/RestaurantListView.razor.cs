using Microsoft.AspNetCore.Components;
using RestaurantReviewsShared.Entities;
using RestaurantReviewsUI.Services;

namespace RestaurantReviewsUI.Components.Pages
{
    public partial class RestaurantListView
    {
        [Inject]
        public IRestaurantsListService? RestaurantListService { get; set; }

        protected IEnumerable<RestaurantVM> RestaurantListViewItems { get; private set; } = [];

        protected override async Task OnInitializedAsync()
        {
            try
            {
                if (RestaurantListService is not null)
                {
                    IList<RestaurantVM> getRestaurantListResult = await RestaurantListService.GetAllRestaurantsAsync();

                    if (getRestaurantListResult != null && getRestaurantListResult.Any())
                    {
                        RestaurantListViewItems = getRestaurantListResult;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }



    }
}
