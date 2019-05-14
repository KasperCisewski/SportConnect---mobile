using MvvmCross.Commands;
using MvvmCross.Navigation;
using SportConnect.Core.Model.User;
using SportConnect.Core.Services.User;
using SportConnect.Core.ViewModels.Base;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace SportConnect.Core.ViewModels.MainApplications.Admin.UsersList
{
    public class UsersListViewModel : BaseViewModel
    {
        private readonly UserService _userService;

        public ObservableCollection<UserModel> UsersList { get; set; }
        public UserModel SelectedUser { get; set; }
        public UsersListViewModel(IMvxNavigationService navigationService, UserService userService) : base(navigationService)
        {
            _userService = userService;
            UsersList = new ObservableCollection<UserModel>();

            FillUsersList().GetAwaiter();
            
        }

        private async Task FillUsersList()
        {
            var existingUsers = await _userService.GetExistingUsers();

            foreach (var user in existingUsers)
            {
                UsersList.Add(user);
            }
        }

        public IMvxAsyncCommand EditUserAccount =>
          new MvxAsyncCommand(async () =>
          {
             
          });

        public IMvxAsyncCommand DeleteUserAccount =>
          new MvxAsyncCommand(async () =>
          {
              
          });           
    }
}
