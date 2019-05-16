using System;
using System.Threading.Tasks;
using SportConnect.Core.Services.User;
using SportConnect.Core.ViewModels.Base;

namespace SportConnect.Core.ViewModels.MainApplications.Admin.UsersList
{
    public class EditUserViewModel : BaseViewModel
    {
        private readonly UserService _userService;

        public EditUserViewModel(UserService userService)
        {
            _userService = userService;
            FillEditFormForUser().GetAwaiter();
        }

        private async Task FillEditFormForUser()
        {
            throw new NotImplementedException();
        }
    }
}
