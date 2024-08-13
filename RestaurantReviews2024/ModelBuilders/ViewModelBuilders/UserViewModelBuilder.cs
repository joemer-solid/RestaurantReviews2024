using RestaurantReviewsService.DomainModels;
using RestaurantReviewsShared.Entities;

namespace RestaurantReviewsService.ModelBuilders.ViewModelBuilders
{
	public sealed class UserViewModelBuilder : IModelBuilder<UserVM, UserDM>
    {       
        UserVM IModelBuilder<UserVM, UserDM>.Build(UserDM p)
        {
            if(p == null) { return new UserVM(); }

            return new UserVM
            {
                Id = p.Id,
                Alias = p.Alias,
                City = p.City,
                FirstName = p.FirstName,
                LastName = p.LastName,
                State = p.State,
                StateIdRef = p.StateIdRef,
                FullName = GetUserFullName(p.FirstName,p.LastName)
            };
        }

        private string GetUserFullName(string firstName, string lastName)
            => string.Format("{0} {1}", firstName.Trim(), lastName.Trim()).Trim();
    }
}