using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using SportConnect.Core.Model.SportEvents;
using SportConnect.Core.Services.SportEvent;
using SportConnect.Core.ViewModels.Base;

namespace SportConnect.Core.ViewModels.MainApplications.Normal.SportEvents
{
    public class SportEventOfUserViewModel : BaseViewModel
    {
        private readonly SportEventService _sportEventService;

        public ObservableCollection<SportEventModel> SportEventList { get; set; }

        public SportEventOfUserViewModel(SportEventService sportEventService)
        {
            _sportEventService = sportEventService;
            SportEventList = new ObservableCollection<SportEventModel>();

            FillSportEvents().GetAwaiter();
            Task.WaitAll();
        }

        private async Task FillSportEvents()
        {
            var eventList = await _sportEventService.GetSportEventsAssignedToUser();

            foreach (var sportEvent in eventList)
            {
                SportEventList.Add(sportEvent);
            }
        }
    }
}
