using MvvmCross.Commands;
using SportConnect.Core.Model.SportEvents;
using SportConnect.Core.Services.SportEvent;
using SportConnect.Core.ViewModels.Base;
using System;
using System.Threading.Tasks;

namespace SportConnect.Core.ViewModels.MainApplications.Normal.SportEvents
{
    public class SportEventViewModel : BaseViewModel<SportEventModel>
    {
        private readonly SportEventService _sportEventService;

        public SportEventViewModel(SportEventService sportEventService)
        {
            _sportEventService = sportEventService;
        }

        public SportEventModel SportEventModel { get; set; }
        public bool IsJoinedToEventInPast { get; set; }


        public override void Prepare(SportEventModel parameter)
        {
            SportEventModel = parameter;
            FillSportEventView().GetAwaiter();
        }

        private async Task FillSportEventView()
        {
            IsJoinedToEventInPast = await _sportEventService.IsUserJoinToEventInPast(SportEventModel.Id, GlobalStateService.UserData.UserId);
            Task.WaitAll();
        }
        public IMvxAsyncCommand JoinToEvent =>
        new MvxAsyncCommand(async () =>
        {
            await _sportEventService.JoinToEvent(SportEventModel.Id, GlobalStateService.UserData.UserId);
            Task.WaitAll();
            await NavigationService.Close(this);
        });
        public IMvxAsyncCommand OutFromEvent =>
        new MvxAsyncCommand(async () =>
        {
            await _sportEventService.OutFromEvent(SportEventModel.Id, GlobalStateService.UserData.UserId);
            Task.WaitAll();
            await NavigationService.Close(this);
        });
    }
}
