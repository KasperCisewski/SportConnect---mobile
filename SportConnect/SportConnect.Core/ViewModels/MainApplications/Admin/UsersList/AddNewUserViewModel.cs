using SportConnect.Core.Services.User;
using SportConnect.Core.ViewModels.Base;

namespace SportConnect.Core.ViewModels.MainApplications.Admin.UsersList
{
    public class AddNewUserViewModel : BaseViewModel
    {
        private readonly UserService _userService;

        public AddNewUserViewModel(UserService userService)
        {
            _userService = userService;
        }
    }
}
