namespace RestaurantReviews2024.App.Services
{
    public class ApiResponse<T>
    {
        public string? Message { get; set; }
        public string? ValidationErrors { get; set; }
        public bool? Success { get; set; }
        public T? Data { get; set; }
    }
}
