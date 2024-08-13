using RestaurantReviewsService.DomainModels;
using RestaurantReviewsShared.Entities;

namespace RestaurantReviewsService.ModelBuilders.ViewModelBuilders
{
    public sealed class UserReviewViewModelBuilder : IModelBuilder<UserReviewVM, UserReviewDM>
    {
        private IModelBuilder<UserVM, UserDM> _userVMBuilder;

        public UserReviewViewModelBuilder()
        {
            _userVMBuilder = new UserViewModelBuilder();
        }

        UserReviewVM IModelBuilder<UserReviewVM, UserReviewDM>.Build(UserReviewDM p)
        {
            return new UserReviewVM
            {
                Comments = p.Comments,
                Id = p.Id,
                RatingsDescription = p.RatingsDescription,
                RatingsLevel = p.RatingsLevel,
                RatingsRef = p.RatingsRef,
                RestaurantIdRef = p.RestaurantIdRef,
                Title = p.Title,
                UserIdRef = p.UserIdRef,
                RatingsRepresentation = TranslateRatingsLevelForRepresentation(p.RatingsLevel),
                UserVM = BuildUserVM(p.User!)               
            };
        }

        private string TranslateRatingsLevelForRepresentation(int ratingsLevel)
        {
            const string STAR = "*";

            string[] ratingsLevelDescriptionBuffer = new string[ratingsLevel];

            for(int i = 0; i < ratingsLevelDescriptionBuffer.Length; i++)
            {
                ratingsLevelDescriptionBuffer[i] = STAR;
            }

            return string.Join(string.Empty, ratingsLevelDescriptionBuffer);
        }


        private UserVM BuildUserVM(UserDM userDM)
        {
            return _userVMBuilder.Build(userDM);
        }
    }
}