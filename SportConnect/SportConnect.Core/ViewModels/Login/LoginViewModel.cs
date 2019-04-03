using System.Collections.Generic;
using Acr.UserDialogs;
using MvvmCross.Commands;
using MvvmCross.Logging;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using SportConnect.Core.Services.Settings;
using SportConnect.Core.ViewModels.Registration;

namespace SportConnect.Core.ViewModels.Login
{
    public class LoginViewModel : MvxViewModel
    {
        private readonly IMvxNavigationService _navigationService;
        private readonly IMvxLogProvider _mvxLogProvider;
        private readonly IAppSettings _settings;
        private readonly IUserDialogs _userDialogs;

        public LoginViewModel(
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

        public string Login { get; set; }
        public string Password { get; set; }
        public bool IsToggled { get; set; }

        public IMvxAsyncCommand LogInCommand { get; }

        //public IMvxCommand LogInCommand
        //{

        //        return new MvxCommand(() =>
        //        {
        //            ButtonText = Resources.AppResources.MainPageButtonPressed;
        //        });

        //}

        public IMvxAsyncCommand GoToRegistrationView =>
            new MvxAsyncCommand(async () =>
            {
                await _navigationService.Navigate<RegistrationViewModel>();
            });
    }
}
