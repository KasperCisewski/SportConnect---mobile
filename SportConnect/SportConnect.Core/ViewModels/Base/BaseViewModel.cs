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
        protected readonly IMvxNavigationService _navigationService;

        [MvxInject]
        public IGlobalStateService GlobalStateService { get; set; }

        public BaseViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;
        }
        public IMvxAsyncCommand ShowSettingsModule =>
            new MvxAsyncCommand(async () =>
            {
                await _navigationService.Navigate<SettingsModuleViewModel>();
            });
    }
}
