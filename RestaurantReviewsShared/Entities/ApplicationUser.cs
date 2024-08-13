using Microsoft.AspNetCore.Identity;
using System;

namespace RestaurantReviewsShared.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser(string firstName, string lastName)
        {
            FirstName = !string.IsNullOrWhiteSpace(firstName) ? firstName : throw new ArgumentNullException(nameof(firstName));
            LastName = !string.IsNullOrWhiteSpace(lastName) ? lastName : throw new ArgumentNullException(nameof(lastName));
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
