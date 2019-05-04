using MvvmCross.Commands;
using MvvmCross.Navigation;
using SportConnect.Core.ViewModels.LoginAndRegistration.Login;

namespace SportConnect.Core.ViewModels.Base
{
    public class MainApplicationViewModelBase : BaseViewModel
    {
        public MainApplicationViewModelBase(IMvxNavigationService navigationService) : base(navigationService)
        {

        }
        public IMvxAsyncCommand LogoutFromApp =>
           new MvxAsyncCommand(async () =>
           {
               await _navigationService.Navigate<LoginViewModel>();
           });
    }
}
