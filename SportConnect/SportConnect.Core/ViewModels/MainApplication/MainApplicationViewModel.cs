using System;
using System.Collections.Generic;
using System.Text;
using Acr.UserDialogs;
using MvvmCross.Logging;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using SportConnect.Core.Services.Settings;
using SportConnect.Core.Services.User;

namespace SportConnect.Core.ViewModels.MainApplication
{
    public class MainApplicationViewModel : MvxViewModel
    {

        private readonly IMvxLogProvider _mvxLogProvider;
        private readonly IAppSettings _settings;
        private readonly IUserDialogs _userDialogs;
        private readonly UserService _userService;
        private readonly IMvxNavigationService _navigationService;

        public MainApplicationViewModel(
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
    }
}
