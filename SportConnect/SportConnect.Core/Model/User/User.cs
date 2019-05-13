using System;

namespace SportConnect.Core.Model.User
{
    public class User
    {
        public Guid Id { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
    }
}
