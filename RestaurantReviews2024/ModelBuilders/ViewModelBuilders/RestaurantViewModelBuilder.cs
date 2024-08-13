using RestaurantReviewsService.DomainModels;
using RestaurantReviewsShared.Entities;
using System.Collections.Generic;


namespace RestaurantReviewsService.ModelBuilders.ViewModelBuilders
{
    public struct RestaurantVMBuilderParams
    {
        public RestaurantDM RestaurantDomainModel { get; set; }

        public IList<UserReviewDM> UserReviewsDMItems { get; set; }
    }

    public sealed class RestaurantViewModelBuilder : IModelBuilder<RestaurantVM, RestaurantVMBuilderParams>
    {
        private IModelBuilder<UserReviewVM, UserReviewDM> _userReviewViewModelBuilder;

        public RestaurantViewModelBuilder()
        {
            _userReviewViewModelBuilder = new UserReviewViewModelBuilder();
        }

        RestaurantVM IModelBuilder<RestaurantVM, RestaurantVMBuilderParams>.Build(RestaurantVMBuilderParams p)
        {
           
            // TODO - change p to a struct containing possibly restaurant reviews
            return new RestaurantVM
            {
                City = p.RestaurantDomainModel.City,
                Id = p.RestaurantDomainModel.Id,
                Name = p.RestaurantDomainModel.Name,
                Overview = p.RestaurantDomainModel.Overview,
                State = p.RestaurantDomainModel.State,
                StateId = p.RestaurantDomainModel.StateId,
                StreetAddress = p.RestaurantDomainModel.StreetAddress,
                UserReviews = BuildUserReviews(p.UserReviewsDMItems)
                
            };
        }

        private IList<UserReviewVM> BuildUserReviews(IList<UserReviewDM> items)
        {
            IList<UserReviewVM> results = new List<UserReviewVM>();

            if (items != null && items.Count > 0)
            {
                foreach (UserReviewDM userReviewDomainModel in items)
                {
                    results.Add(_userReviewViewModelBuilder.Build(userReviewDomainModel));
                }
            }

            return results;
        }
    }
}