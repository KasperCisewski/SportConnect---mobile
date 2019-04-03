using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using Acr.UserDialogs;
using MvvmCross.Commands;
using MvvmCross.Logging;
using MvvmCross.Navigation;
using SportConnect.Core.Services.Settings;

namespace SportConnect.Core.ViewModels.Registration
{
    public class RegistrationViewModel : MvxViewModel
    {
        private readonly IMvxNavigationService _navigationService;
        private readonly IMvxLogProvider _mvxLogProvider;
        private readonly IAppSettings _settings;
        private readonly IUserDialogs _userDialogs;

        public RegistrationViewModel(
            IMvxNavigationService navigationService,
            IMvxLogProvider mvxLogProvider,
            IAppSettings settings,
            IUserDialogs userDialogs)
        {
            _navigationService = navigationService;
            _mvxLogProvider = mvxLogProvider;
            _settings = settings;
            _userDialogs = userDialogs;
        }

        public string Email { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string RepeatedPassword { get; set; }
        public string EmailNotValidatedMessage { get; set; }
        public bool IsEmailNotValidated { get; set; }
        public string LoginNotValidatedMessage { get; set; }
        public bool IsLoginNotValidated { get; set; }
        public string PasswordNotValidatedMessage { get; set; }

        public bool IsPasswordNotValidated { get; set; }
        public string SecondPasswordNotValidatedMessage { get; set; }
        public bool IsSecondPasswordNotValidated { get; set; }

        public IMvxAsyncCommand CheckValidationEmailCommand =>
            new MvxAsyncCommand(async () => { ValidateEmail(); });

        private void ValidateEmail()
        {
            IsEmailNotValidated = !IsEmailNotValidated;
            EmailNotValidatedMessage = "test";

        }

        public IMvxAsyncCommand CheckValidationLoginCommand =>
            new MvxAsyncCommand(async () => { ValidateAndRegister(); });

        public IMvxAsyncCommand CheckValidationPasswordCommand =>
            new MvxAsyncCommand(async () => { ValidateAndRegister(); });

        public IMvxAsyncCommand CheckValidationRepeatedPasswordCommand =>
            new MvxAsyncCommand(async () => { ValidateAndRegister(); });

        public IMvxAsyncCommand RegisterCommand =>
            new MvxAsyncCommand(async () => { ValidateAndRegister(); });


        private async void ValidateAndRegister()
        {
            if (!IsEmailNotValidated &&
                !IsLoginNotValidated &&
                !IsPasswordNotValidated &&
                !IsSecondPasswordNotValidated)
            {

            }
        }

    }
}
