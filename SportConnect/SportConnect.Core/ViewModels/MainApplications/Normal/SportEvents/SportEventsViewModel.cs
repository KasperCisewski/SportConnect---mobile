using MvvmCross.Commands;
using MvvmCross.Navigation;
using SportConnect.Core.Model.SportEvents;
using SportConnect.Core.Services.SportEvent;
using SportConnect.Core.ViewModels.Base;
using SportConnect.Core.ViewModels.MainApplications.Normal.SportEvents.AddSportEvent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace SportConnect.Core.ViewModels.MainApplications.Normal.SportEvents
{
    public class SportEventsViewModel : BaseViewModel
    {
        private readonly SportEventService _sportEventService;

        public SportEventsViewModel(
            SportEventService sportEventService) 
        {
            _sportEventService = sportEventService;
            SportEventList = new ObservableCollection<SportEventModel>();

            FillSportEventList().GetAwaiter();
        }

        public override void ViewAppearing()
        {
            FillSportEventList().GetAwaiter();
            base.ViewAppearing();
        }

        public ObservableCollection<SportEventModel> SportEventList { get; set; }
        public SportEventModel SportEventSelected { get; set; }
        public IMvxAsyncCommand AddSportEvent =>
         new MvxAsyncCommand(async () =>
         {
             await NavigationService.Navigate<AddSportEventViewModel>();
         });

        public async Task GoToSportEventView()
        {
            await NavigationService.Navigate<SportEventViewModel, SportEventModel>(SportEventSelected);
        }
        
        public async Task FillSportEventList()
        {
            var eventList = await _sportEventService.GetSportEventsAsync(new System.Guid());

            SportEventList.Clear();
            foreach (var sportEvent in eventList)
            {
                SportEventList.Add(sportEvent);
            }
        }
    }
}
