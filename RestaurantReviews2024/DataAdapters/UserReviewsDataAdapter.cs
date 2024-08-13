using RestaurantReviewService.Entities;
using RestaurantReviewService.Operations;
using RestaurantReviewServiceRepository.Operations;
using RestaurantReviewsService.DomainModels;
using RestaurantReviewsService.ModelBuilders.DataEntityModelBuilders;
using RestaurantReviewsService.ModelBuilders.DomainModelBuilders;
using RestaurantReviewsService.ModelBuilders;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;

namespace RestaurantReviews2024.DataAdapters
{
    public class UserReviewsDataAdapter  : IUserReviewsDataAdapter
    {
        async Task<int> IUserReviewsDataAdapter.AddNewUserReview(UserReviewDM userReviewDM)
        {
            IModelBuilder<UserReview, UserReviewDM> domainToEntityModelBuilder = new UserReviewDomainEntityModelBuilder();

            AddNewUserReviewOperation addNewUserReviewOperation = new AddNewUserReviewOperation();

            UserReview userReviewDataEntity = domainToEntityModelBuilder.Build(userReviewDM);

			await Task.CompletedTask;

			return addNewUserReviewOperation.AddNewUserReview(userReviewDataEntity);
        }

        async Task<int> IUserReviewsDataAdapter.DeleteExistingUserReview(UserReviewDM userReviewDM)
        {
            throw new NotImplementedException();
        }

        async Task<IList<UserReviewDM>> IUserReviewsDataAdapter.GetUserReviewsForRestaurant(RestaurantDM restaurantDm)
        {
            ISelectUserReviewsOperation selectUserReviewsOperation = new SelectUserReviewsOperation();

            IList<UserReview> operationResults = selectUserReviewsOperation.SelectByRestaurant(
                new Restaurant() { Id = restaurantDm.Id });

			await Task.CompletedTask;

			return BuildUserReviewDomainModelList(operationResults);
        }

        async Task<IList<UserReviewDM>> IUserReviewsDataAdapter.GetUserReviewsForUser(UserDM userDm)
        {
            ISelectUserReviewsOperation selectUserReviewsOperation = new SelectUserReviewsOperation();

            IList<UserReview> operationResults = selectUserReviewsOperation.SelectByUser(
                new User() { Id = userDm.Id });

			await Task.CompletedTask;

			return BuildUserReviewDomainModelList(operationResults);
        }

        private IList<UserReviewDM> BuildUserReviewDomainModelList(IList<UserReview> operationResults)
        {
            IList<UserReviewDM> results = new List<UserReviewDM>();
            IModelBuilder<UserReviewDM, UserReview> modelBuilder = new UserReviewDomainModelBuilder();

            if (operationResults != null && operationResults.Count > 0)
            {
                foreach (UserReview userReview in operationResults)
                {
                    results.Add(modelBuilder.Build(userReview));
                }
            }

            return results;
        }
    }
}
