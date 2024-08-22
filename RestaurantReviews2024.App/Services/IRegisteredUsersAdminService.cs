using RestaurantReviewsShared.Entities;

namespace RestaurantReviews2024.App.Services
{
    public interface IRegisteredUsersAdminService
    {
        Task<IList<TestUser>> GetAllRegisteredUsersAsync();
    }
}
