using MvvmCross.Commands;
using MvvmCross.Navigation;
using SportConnect.Core.Services.SportEvent;
using SportConnect.Core.ViewModels.Base;

namespace SportConnect.Core.ViewModels.MainApplications.Normal.SportEvents
{
    public class SportEventsViewModel : BaseViewModel
    {
        private readonly SportEventService _sportEventService;

        public SportEventsViewModel(
            IMvxNavigationService navigationService,
            SportEventService sportEventService) : base(navigationService)
        {
            _sportEventService = sportEventService;
            var cos = _sportEventService.GetSportEventsAsync(new System.Guid());
        }
        public IMvxAsyncCommand AddSportEvent =>
         new MvxAsyncCommand(async () =>
         {
             await _navigationService.Navigate<AddSportEventViewModel>();
         });
    }
}
