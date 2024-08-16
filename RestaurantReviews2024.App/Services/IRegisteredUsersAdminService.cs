using RestaurantReviewsShared.Identity;

namespace RestaurantReviews2024.App.Services
{
    public interface IRegisteredUsersAdminService
    {
        Task<IList<TestUser>> GetAllRegisteredUsersAsync();
    }
}
