using Acr.UserDialogs;
using MvvmCross.Commands;
using MvvmCross.Logging;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using SportConnect.Core.Services.Settings;

namespace SportConnect.Core.ViewModels
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

        public IMvxAsyncCommand LogInCommand { get; }

        //public IMvxCommand LogInCommand
        //{
          
        //        return new MvxCommand(() =>
        //        {
        //            ButtonText = Resources.AppResources.MainPageButtonPressed;
        //        });
            
        //}
            
    }
}
