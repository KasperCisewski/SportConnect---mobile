using System.Linq;
using System.Threading.Tasks;
using Acr.UserDialogs;
using MvvmCross.Commands;
using MvvmCross.Logging;
using MvvmCross.Navigation;
using SportConnect.Core.Resources.LoginAndRegisterResources;
using SportConnect.Core.Services.Settings;
using SportConnect.Core.Services.User;
using SportConnect.Core.ViewModels.Base;

namespace SportConnect.Core.ViewModels.Registration
{
    public class RegistrationViewModel : BaseViewModel
    {
        private readonly IMvxNavigationService _navigationService;
        private readonly IMvxLogProvider _mvxLogProvider;
        private readonly IAppSettings _settings;
        private readonly IUserDialogs _userDialogs;
        private readonly UserService _userService;

        public RegistrationViewModel(
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
        public string RepeatedPasswordNotValidatedMessage { get; set; }
        public bool IsSecondPasswordNotValidated { get; set; }

        public IMvxAsyncCommand RegisterCommand =>
            new MvxAsyncCommand(async () => { await ValidateAndRegister(); });



        private async Task ValidateAndRegister()
        {
            if (IsEmailNotValidated &&
                IsLoginNotValidated &&
                IsPasswordNotValidated &&
                IsSecondPasswordNotValidated)
            {
            }
            else
            {
                await ValidateEmail();
                await ValidateLogin();
                await ValidatePassword();
                await ValidateRepeatedPassword();
            }
        }


        public async Task ValidateEmail()
        {
            IsEmailNotValidated = false;

            if (Email == null || !Email.Contains("@"))
            {
                EmailNotValidatedMessage =
                    LoginAndRegisterResources.NotValidEmail;
                IsEmailNotValidated = true;
            }

        }

        public async Task ValidateLogin()
        {
            IsLoginNotValidated = false;

            if (Login == null || Login.Length < 3)
            {
                LoginNotValidatedMessage =
                    LoginAndRegisterResources.LoginIsTooShort;
                IsLoginNotValidated = true;
            }

            // if(_userService.)

        }

        public async Task ValidatePassword()
        {
            IsPasswordNotValidated = false;

            if (Password == null ||
                Password.Any(char.IsDigit) &&
                Password.Length < 6)
            {
                PasswordNotValidatedMessage =
                    LoginAndRegisterResources.PasswordIsNotValid;
                IsPasswordNotValidated = true;
            }
            ValidateRepeatedPassword();
        }

        public async Task ValidateRepeatedPassword()
        {
            IsSecondPasswordNotValidated = false;

            if (RepeatedPassword == null ||
                RepeatedPassword != Password)
            {
                RepeatedPasswordNotValidatedMessage =
                    LoginAndRegisterResources.RepeatedPasswordIsNotAsPassword;
                IsSecondPasswordNotValidated = true;
            }

        }
    }
}
