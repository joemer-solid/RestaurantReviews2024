namespace RestaurantReviewsShared.Entities
{
    public class UserReviewVM
    {
        public int Id { get; set; }

        public int UserIdRef { get; set; }

        public int RestaurantIdRef { get; set; }

        public string? Title { get; set; }

        public string? Comments { get; set; }

        public UserReviewRatingLevel ReviewRatingLevel { get => (UserReviewRatingLevel) RatingsLevel; }

        public int RatingsRef { get; set; }

        public int RatingsLevel { get; set; }

        public string? RatingsDescription { get; set; }

        public string? RatingsRepresentation { get; set; }

        public UserVM? UserVM { get; set; }
        
    }
}
