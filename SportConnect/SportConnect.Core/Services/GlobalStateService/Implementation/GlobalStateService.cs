using SportConnect.Core.Model.UserData;
using SportConnect.Core.Services.GlobalStateService.Abstraction;

namespace SportConnect.Core.Services.GlobalStateService.Implementation
{
    public class GlobalStateService : IGlobalStateService
    {
        private static readonly object Lock = new object();
        private static AuthorizationTokenUserModel _user;
        public AuthorizationTokenUserModel UserData
        {
            get
            {
                return _user ?? new AuthorizationTokenUserModel();
            }
            set
            {
                lock (Lock)
                {
                    if(value == null)
                    {
                        _user = new AuthorizationTokenUserModel();
                    }
                    else
                    {
                        _user = value;
                    }
                }
            }
        }
    }
}
