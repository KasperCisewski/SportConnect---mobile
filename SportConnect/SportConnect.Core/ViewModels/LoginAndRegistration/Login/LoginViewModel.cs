using System.Threading.Tasks;
using Acr.UserDialogs;
using MvvmCross.Commands;
using MvvmCross.Logging;
using MvvmCross.Navigation;
using SportConnect.Core.Data.Enums.UserRole;
using SportConnect.Core.Repository.Implementation;
using SportConnect.Core.Resources.LoginAndRegisterResources;
using SportConnect.Core.Services.Settings;
using SportConnect.Core.Services.User;
using SportConnect.Core.Services.ViewHistory;
using SportConnect.Core.ViewModels.Base;
using SportConnect.Core.ViewModels.LoginAndRegistration.Registration;
using SportConnect.Core.ViewModels.MainApplications.Admin;
using SportConnect.Core.ViewModels.MainApplications.Normal;

namespace SportConnect.Core.ViewModels.LoginAndRegistration.Login
{
    public class LoginViewModel : BaseViewModel
    {
        private readonly IMvxLogProvider _mvxLogProvider;
        private readonly IAppSettings _settings;
        private readonly IUserDialogs _userDialogs;
        private readonly UserService _userService;
        private readonly UserRepository _userRepository;
        private readonly IViewHistoryService _viewHistoryService;

        public LoginViewModel(
            IMvxNavigationService navigationService,
            IMvxLogProvider mvxLogProvider,
            IAppSettings settings,
            IUserDialogs userDialogs,
            IViewHistoryService viewHistoryService,
            UserService userService,
            UserRepository userRepository) : base(navigationService)
        {
            _mvxLogProvider = mvxLogProvider;
            _settings = settings;
            _userDialogs = userDialogs;
            _userService = userService;
            _userRepository = userRepository;
            _viewHistoryService = viewHistoryService;
        }
        public override void Prepare()
        {
            var loginCredentialModel = _userRepository.GetUserCredentials();

            if (loginCredentialModel != null)
            {
                Login = loginCredentialModel.Login;
                Password = loginCredentialModel.Password;
            }

            base.Prepare();
        }

        public string Login { get; set; }
        public string Password { get; set; }
        public bool RememberCredentials { get; set; } = true;
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

                if (result.IsSuccess)
                {
                    if (RememberCredentials)
                    {
                        _userRepository.SaveCredentials(new Model.Credentials.LoginCredentialsModel
                        {
                            Login = Login,
                            Password = Password
                        });
                    }

                    GlobalStateService.UserData = new Model.UserData.AuthorizationTokenUserModel
                    {
                        Login = result.Login,
                        Email = result.Email,
                        UserId = result.UserId.Value
                    };

                    if (result.UserRoleId == (int)UserRole.Administrator)
                    {
                        await ShowViewModelAndRemoveHistoryAsync<MainAdminAppViewModel>();
                    }
                    else
                    {
                        await ShowViewModelAndRemoveHistoryAsync<MainNormalAppViewModel>();
                    }
                }
                else
                {
                    IsLoginOrPasswordIsnCorrect = true;
                    LoginOrPasswordIsnCorrectMessage = LoginAndRegisterResources.LoginOrPasswordIsnMatch;
                }
            }
        }

        private async Task ShowViewModelAndRemoveHistoryAsync<T>() where T : BaseViewModel
        {
            _viewHistoryService.ClearHistory();
            await _navigationService.Navigate<T>();
        }

        public IMvxAsyncCommand GoToRegistrationView =>
            new MvxAsyncCommand(async () =>
            {
                await _navigationService.Navigate<RegistrationViewModel>();
            });
    }
}
