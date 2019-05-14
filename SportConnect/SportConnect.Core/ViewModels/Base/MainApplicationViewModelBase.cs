using MvvmCross.Commands;
using MvvmCross.Navigation;
using SportConnect.Core.ViewModels.LoginAndRegistration.Login;

namespace SportConnect.Core.ViewModels.Base
{
    public class MainApplicationViewModelBase : BaseViewModel
    {
        public IMvxAsyncCommand LogoutFromApp =>
           new MvxAsyncCommand(async () =>
           {
               await NavigationService.Navigate<LoginViewModel>();
           });
    }
}
