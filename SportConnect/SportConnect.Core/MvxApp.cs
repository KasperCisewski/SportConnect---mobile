﻿using Acr.UserDialogs;
using MvvmCross;
using MvvmCross.Base;
using MvvmCross.IoC;
using MvvmCross.Logging;
using MvvmCross.Plugin.Json;
using MvvmCross.ViewModels;
using SportConnect.Core.Repository.Implementation;
using SportConnect.Core.Services.Logger;
using SportConnect.Core.Services.Registration;
using SportConnect.Core.Services.Settings;
using SportConnect.Core.Services.SportEvent;
using SportConnect.Core.Services.SportType;
using SportConnect.Core.Services.User;
using SportConnect.Core.ViewModels.Base;
using SportConnect.Core.ViewModels.LoginAndRegistration.Login;
using SportConnect.Core.ViewModels.MainApplications.Admin;
using SportConnect.Core.ViewModels.MainApplications.Normal.Profile;
using SportConnect.Core.ViewModels.MainApplications.Normal.SportEvents;
using SportConnect.Core.ViewModels.MainApplications.Normal.SportEvents.AddSportEvent;
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
            Mvx.IoCProvider.RegisterType<SportEventService>();
            Mvx.IoCProvider.RegisterType<SportTypeService>();
            Mvx.IoCProvider.RegisterType<ILoggerService, LoggerService>();
            Mvx.IoCProvider.RegisterType<IRestClient, RestClient>();
            Mvx.IoCProvider.RegisterSingleton(() => new RestClient(Mvx.IoCProvider.Resolve<IMvxJsonConverter>(), Mvx.IoCProvider.Resolve<IMvxLog>()));

            Mvx.IoCProvider.RegisterType<BaseViewModel>();
            Mvx.IoCProvider.RegisterType<LoginViewModel>();
            Mvx.IoCProvider.RegisterType<MainAdminAppViewModel>();
            Mvx.IoCProvider.RegisterType<AddSportEventViewModel>();
            Mvx.IoCProvider.RegisterType<SportEventsViewModel>();
            Mvx.IoCProvider.RegisterType<ProfileViewModel>();

            Resources.AppResources.Culture = Mvx.IoCProvider.Resolve<Services.ILocalizeService>().GetCurrentCultureInfo();
            RegisterAppStart<LoginViewModel>();
        }
    }
}