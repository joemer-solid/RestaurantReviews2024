using System;

namespace RestaurantReviewsShared.Entities
{
    public class UserStatus
    {
        private string? _userStatus;

        public UserStatus(string userName)
        {
            UserName = !String.IsNullOrEmpty(userName) ? userName : throw new ArgumentNullException(nameof(userName));
        }
        public string UserName { get; private set; }

        public string? Status
        {
            get { return _userStatus; }
            set
            {
                _userStatus = value;
                StatusChange = DateTime.UtcNow;
            }
        }

        public DateTime StatusChange { get; private set; }
    }
}
