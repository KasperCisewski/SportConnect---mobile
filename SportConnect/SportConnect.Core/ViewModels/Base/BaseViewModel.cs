using MvvmCross.Commands;
using MvvmCross.IoC;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using SportConnect.Core.Services.GlobalStateService.Abstraction;
using SportConnect.Core.ViewModels.MainApplications.Normal.SettingsModule;
using System;

namespace SportConnect.Core.ViewModels.Base
{
    public class BaseViewModel : MvxViewModel
    {

        [MvxInject]
        public IMvxNavigationService NavigationService { get; set; }

        [MvxInject]
        public IGlobalStateService GlobalStateService { get; set; }

        public IMvxAsyncCommand ShowSettingsModule =>
            new MvxAsyncCommand(async () =>
            {
                await NavigationService.Navigate<SettingsModuleViewModel>();
            });
    }
}
