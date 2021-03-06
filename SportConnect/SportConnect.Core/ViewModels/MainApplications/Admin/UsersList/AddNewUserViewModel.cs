﻿using System;
using System.Threading.Tasks;
using Acr.UserDialogs;
using MvvmCross.Commands;
using SportConnect.Core.Services.Registration;
using SportConnect.Core.ViewModels.Base;

namespace SportConnect.Core.ViewModels.MainApplications.Admin.UsersList
{
    public class AddNewUserViewModel : BaseViewModel
    {
        private readonly IUserDialogs _userDialogs;
        private readonly RegistrationService _registrationService;

        public AddNewUserViewModel(IUserDialogs userDialogs,
            RegistrationService registrationService)
        {
            _userDialogs = userDialogs;
            _registrationService = registrationService;
        }

        public string Email { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public IMvxAsyncCommand AddNewUserCommand =>
           new MvxAsyncCommand(async () => { await RegisterNewUser(); });

        private async Task RegisterNewUser()
        {
            if (!string.IsNullOrWhiteSpace(Email) &&
                 !string.IsNullOrWhiteSpace(Login) &&
                 !string.IsNullOrWhiteSpace(Password))
            {
                await _registrationService.TryToRegisterUserAsync(new RegistrationResponseApiModel(Login, Email, Password));

                await NavigationService.Close(this);

            }
        }
    }
}
