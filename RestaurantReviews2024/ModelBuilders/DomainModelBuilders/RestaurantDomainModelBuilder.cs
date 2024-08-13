using RestaurantReviewService.Entities;
using RestaurantReviewsService.DomainModels;
using RestaurantReviewsShared.Entities;

namespace RestaurantReviewsService.ModelBuilders.DomainModelBuilders
{
    public sealed class RestaurantDomainModelBuilder : IModelBuilder<RestaurantDM, Restaurant>,
        IModelBuilder<RestaurantDM, RestaurantVM>
    {
        RestaurantDM IModelBuilder<RestaurantDM, Restaurant>.Build(Restaurant p)
        {
            return new RestaurantDM
            {
                City = p.City,
                Id = p.Id,
                Name = p.Name,
                Overview = p.Overview,
                State = p.State,
                StateId = p.StateIdRef,
                StreetAddress = p.StreetAddress
            };
        }

        RestaurantDM IModelBuilder<RestaurantDM, RestaurantVM>.Build(RestaurantVM p)
        {
            if(p == null) { return new RestaurantDM(); }
            return new RestaurantDM
            {
                City = p.City,
                Id = p.Id,
                Name = p.Name,
                Overview = p.Overview,
                StateId = p.StateId,
                StreetAddress = p.StreetAddress,
                State = p.State
            };
        }
    }
}