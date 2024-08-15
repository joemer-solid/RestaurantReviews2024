namespace RestaurantReviewsUI.Services
{
    public abstract class CrossSiteRequestForgeryTokenBase
    {
        public string XsrfToken { get; set; } = string.Empty;
    }

    public sealed class TokenProvider : CrossSiteRequestForgeryTokenBase
    {
    }

    public sealed class InitialApplicationState : CrossSiteRequestForgeryTokenBase
    {      
    }
}
