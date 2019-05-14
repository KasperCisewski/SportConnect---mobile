using System;

namespace SportConnect.Core.Model.UserData
{
    public class AuthorizationTokenUserModel
    {
        public Guid UserId { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
    }
}
