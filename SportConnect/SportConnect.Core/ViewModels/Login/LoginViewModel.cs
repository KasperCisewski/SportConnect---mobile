using System.Collections.Generic;
using System.Threading.Tasks;
using Acr.UserDialogs;
using MvvmCross.Commands;
using MvvmCross.Logging;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using SportConnect.Core.Resources.LoginAndRegisterResources;
using SportConnect.Core.Services.Settings;
using SportConnect.Core.Services.User;
using SportConnect.Core.ViewModels.MainApplication;
using SportConnect.Core.ViewModels.Registration;

namespace SportConnect.Core.ViewModels.Login
{
    public class LoginViewModel : MvxViewModel
    {
        private readonly IMvxNavigationService _navigationService;
        private readonly IMvxLogProvider _mvxLogProvider;
        private readonly IAppSettings _settings;
        private readonly IUserDialogs _userDialogs;
        private readonly UserService _userService;

        public LoginViewModel(
            IMvxNavigationService navigationService,
            IMvxLogProvider mvxLogProvider,
            IAppSettings settings,
            IUserDialogs userDialogs,
            UserService userService)
        {
            _navigationService = navigationService;
            _mvxLogProvider = mvxLogProvider;
            _settings = settings;
            _userDialogs = userDialogs;
            _userService = userService;
        }

        public string Login { get; set; }
        public string Password { get; set; }
        public bool IsToggled { get; set; }
        public bool IsLoginOrPasswordIsnCorrect { get; set; }
        public string LoginOrPasswordIsnCorrectMessage { get; set; }

        public IMvxAsyncCommand LogInCommand =>
            new MvxAsyncCommand(async () => { await TryToLogIn(); });

        private async Task TryToLogIn()
        {
            IsLoginOrPasswordIsnCorrect = false;
            if (Login != null || Password != null)
            {
                var result = await _userService.TryToLogIntoApp(Login, Password);

                if (result)
                {
                    await _navigationService.Navigate<MainApplicationViewModel>();
                }
                else
                {
                    IsLoginOrPasswordIsnCorrect = true;
                    LoginOrPasswordIsnCorrectMessage = LoginAndRegisterResources.LoginOrPasswordIsnMatch;
                }
            }
        }

        public IMvxAsyncCommand GoToRegistrationView =>
            new MvxAsyncCommand(async () =>
            {
                await _navigationService.Navigate<RegistrationViewModel>();
            });
    }
}
