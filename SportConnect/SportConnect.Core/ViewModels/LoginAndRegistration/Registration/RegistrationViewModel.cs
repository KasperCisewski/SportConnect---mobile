using System.Linq;
using System.Threading.Tasks;
using Acr.UserDialogs;
using MvvmCross.Commands;
using MvvmCross.Logging;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using SportConnect.Core.Resources.LoginAndRegisterResources;
using SportConnect.Core.Services.Registration;
using SportConnect.Core.Services.Settings;
using SportConnect.Core.Services.User;

namespace SportConnect.Core.ViewModels.LoginAndRegistration.Registration
{
    public class RegistrationViewModel : MvxViewModel
    {
        private readonly IMvxNavigationService _navigationService;
        private readonly IMvxLogProvider _mvxLogProvider;
        private readonly IAppSettings _settings;
        private readonly IUserDialogs _userDialogs;
        private readonly UserService _userService;
        private readonly RegistrationService _registrationService;

        public RegistrationViewModel(
            IMvxNavigationService navigationService,
            IMvxLogProvider mvxLogProvider,
            IAppSettings settings,
            IUserDialogs userDialogs,
            UserService userService,
            RegistrationService registrationService)
        {
            _navigationService = navigationService;
            _mvxLogProvider = mvxLogProvider;
            _settings = settings;
            _userDialogs = userDialogs;
            _userService = userService;
            _registrationService = registrationService;
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
            if (!IsEmailNotValidated &&
                !IsLoginNotValidated &&
                !IsPasswordNotValidated &&
                !IsSecondPasswordNotValidated)
            {
                var isRegistered = await _registrationService.TryToRegisterUserAsync(new RegistrationResponseApiModel(Login, Email, Password));

                if (isRegistered)
                {
                    _userDialogs.Alert(new AlertConfig() { Message = "You register into app" });
                    await ClearAllAppValues();
                }
                else
                {
                    _userDialogs.Alert(new AlertConfig() { Message = "Sorry, we can't register you" });
                }
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
            if (Email != null)
            {
                if (!Email.Contains("@"))
                {
                    EmailNotValidatedMessage =
                        LoginAndRegisterResources.NotValidEmailByNotContainAt;
                    IsEmailNotValidated = true;
                    return;
                }

                if (Email.Length < 3)
                {
                    EmailNotValidatedMessage =
                        LoginAndRegisterResources.EmailIsTooShort;
                    IsEmailNotValidated = true;
                    return;
                }

                var result = await _userService.ValidateEmailByCheckIfExistInApp(Email);
                if (result)
                {
                    EmailNotValidatedMessage =
                        LoginAndRegisterResources.EmailAlreadyIsInApplication;
                    IsEmailNotValidated = true;
                }
            }
        }

        public async Task ValidateLogin()
        {
            IsLoginNotValidated = false;

            if (Login != null)
            {

                if (Login.Length < 3)
                {
                    LoginNotValidatedMessage =
                        LoginAndRegisterResources.LoginIsTooShort;
                    IsLoginNotValidated = true;
                    return;
                }

                var result = await _userService.ValidateLoginByCheckIfExistInApp(Login);

                if (result)
                {
                    LoginNotValidatedMessage =
                        LoginAndRegisterResources.LoginAlreadyIsInApplication;
                    IsLoginNotValidated = true;
                }
            }
        }

        public async Task ValidatePassword()
        {
            IsPasswordNotValidated = false;

            if (Password == null ||
                !Password.Any(char.IsDigit) &&
                Password.Length < 6)
            {
                PasswordNotValidatedMessage =
                    LoginAndRegisterResources.PasswordIsNotValid;
                IsPasswordNotValidated = true;
            }
            await ValidateRepeatedPassword();
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

        public async Task ClearAllAppValues()
        {
            Login = string.Empty;
            Password = string.Empty;
            Email = string.Empty;
            RepeatedPassword = string.Empty;
        }
    }
}
