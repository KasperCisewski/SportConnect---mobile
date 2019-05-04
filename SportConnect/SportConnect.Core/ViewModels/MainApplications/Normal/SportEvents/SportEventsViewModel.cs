using MvvmCross.Commands;
using MvvmCross.Navigation;
using SportConnect.Core.ViewModels.Base;

namespace SportConnect.Core.ViewModels.MainApplications.Normal.SportEvents
{
    public class SportEventsViewModel : BaseViewModel
    {
        public SportEventsViewModel(IMvxNavigationService navigationService) : base(navigationService)
        {

        }
        public IMvxAsyncCommand AddSportEvent =>
         new MvxAsyncCommand(async () =>
         {
             await _navigationService.Navigate<AddSportEventViewModel>();
         });      
    }
}
