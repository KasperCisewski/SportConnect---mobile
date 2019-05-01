using Acr.UserDialogs;
using MvvmCross;
using MvvmCross.Base;
using MvvmCross.IoC;
using MvvmCross.Logging;
using MvvmCross.Plugin.Json;
using MvvmCross.ViewModels;
using SportConnect.Core.Repository.Abstraction;
using SportConnect.Core.Repository.Implementation;
using SportConnect.Core.Services.Logger;
using SportConnect.Core.Services.Registration;
using SportConnect.Core.Services.Settings;
using SportConnect.Core.Services.User;
using SportConnect.Core.Services.ViewHistory;
using SportConnect.Core.ViewModels.Base;
using SportConnect.Core.ViewModels.Login;
using Xamarin.Essentials;
using IRestClient = SportConnect.Core.Services.Rest.Interfaces.IRestClient;
using RestClient = SportConnect.Core.Services.Rest.Implementations.RestClient;

namespace SportConnect.Core
{
    public class MvxApp : MvxApplication
    {

        public static string IPAddress = DeviceInfo.Platform == DevicePlatform.Android ? "10.0.2.2" : "localhost";
        public static string BackendUrl = $"http://{IPAddress}:5000";
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            CreatableTypes().
                EndingWith("Repository")
                .AsTypes()
                .RegisterAsLazySingleton();

            Mvx.IoCProvider.RegisterType<IAppSettings, AppSettings>();
            Mvx.IoCProvider.RegisterType<IMvxJsonConverter, MvxJsonConverter>();
            Mvx.IoCProvider.RegisterSingleton<IUserDialogs>(() => UserDialogs.Instance);
            Mvx.IoCProvider.RegisterType<UserRepository>();
            Mvx.IoCProvider.RegisterType<UserService>();
            Mvx.IoCProvider.RegisterType<RegistrationService>();
            Mvx.IoCProvider.RegisterType<BaseViewModel>();
            Mvx.IoCProvider.RegisterType<LoginViewModel>();
            Mvx.IoCProvider.RegisterType<ILoggerService, LoggerService>();
            Mvx.IoCProvider.RegisterType<IRestClient, RestClient>();
            Mvx.IoCProvider.RegisterSingleton(() => new RestClient(Mvx.IoCProvider.Resolve<IMvxJsonConverter>(), Mvx.IoCProvider.Resolve<IMvxLog>()));
            Resources.AppResources.Culture = Mvx.IoCProvider.Resolve<Services.ILocalizeService>().GetCurrentCultureInfo();
            RegisterAppStart<LoginViewModel>();
        }
    }
}