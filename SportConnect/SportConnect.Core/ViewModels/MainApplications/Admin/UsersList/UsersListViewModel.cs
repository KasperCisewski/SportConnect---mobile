﻿using MvvmCross.Commands;
using SportConnect.Core.Model.User;
using SportConnect.Core.Services.User;
using SportConnect.Core.ViewModels.Base;
using System.Collections.ObjectModel;
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

        public IMvxAsyncCommand EditUserAccount =>
          new MvxAsyncCommand(async () =>
          {
             
          });

        public IMvxAsyncCommand DeleteUserAccount =>
          new MvxAsyncCommand(async () =>
          {
              
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
}
