using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using SportConnect.Core.ViewModels.MainApplications.Normal.SettingsModule;

namespace SportConnect.Core.ViewModels.Base
{
    public class BaseViewModel : MvxViewModel
    {
        protected readonly IMvxNavigationService _navigationService;

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
