using MvvmCross.Commands;
using MvvmCross.Navigation;
using SportConnect.Core.Model.User;
using SportConnect.Core.Services.User;
using SportConnect.Core.ViewModels.Base;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace SportConnect.Core.ViewModels.MainApplications.Admin.UsersList
{
    public class UsersListViewModel : BaseViewModel
    {
        private readonly UserService _userService;

        public ObservableCollection<UserModel> UsersList { get; set; }
        public UserModel SelectedUser { get; set; }
        public UsersListViewModel(UserService userService)
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

        public async Task GoToEditUserView()
        {
            EditUserModel editUserModel;
            if (SelectedUser == null)
            {
                editUserModel = new EditUserModel
                {
                    UserId = UsersList.First().Id
                };
            }
            else
            {
                editUserModel = new EditUserModel
                {
                    UserId = SelectedUser.Id
                };
            }

            await NavigationService.Navigate<EditUserViewModel, EditUserModel>(editUserModel);
        }
        public async Task DeleteUser()
        {
            await _userService.DeleteUser(SelectedUser.Id);
        }

        public IMvxAsyncCommand EditUserAccount =>
          new MvxAsyncCommand(async () =>
          {
              var editUserModel = new EditUserModel
              {
                  UserId = SelectedUser.Id
              };
              await NavigationService.Navigate<EditUserViewModel, EditUserModel>(editUserModel);
          });


        public IMvxAsyncCommand DeleteUserAccount =>
          new MvxAsyncCommand(async () =>
          {
              await _userService.DeleteUser(SelectedUser.Id);
          });

        public IMvxAsyncCommand GoToAddNewAccountView =>
          new MvxAsyncCommand(async () =>
          {
              await NavigationService.Navigate<AddNewUserViewModel>();
          });

        public IMvxAsyncCommand ShowUsersLogRecords =>
          new MvxAsyncCommand(async () =>
          {
              await NavigationService.Navigate<UserLogRecordsViewModel>();
          });


    }
    public class EditUserModel
    {
        public Guid UserId { get; set; }
    }
}
