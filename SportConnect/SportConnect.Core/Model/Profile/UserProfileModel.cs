using System;

namespace SportConnect.Core.Model.Profile
{
    public class UserProfileModel
    {
        public Guid UserId { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public int FacouriteSportTypeId { get; set; }
    }
}
