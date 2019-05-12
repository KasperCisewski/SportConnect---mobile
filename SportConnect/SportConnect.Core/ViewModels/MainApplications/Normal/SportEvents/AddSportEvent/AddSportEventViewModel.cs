﻿using MvvmCross.Commands;
using MvvmCross.Navigation;
using SportConnect.Core.Data.Enums.SportSkillLevel;
using SportConnect.Core.Model.SportType;
using SportConnect.Core.Services.SportType;
using SportConnect.Core.Services.User;
using SportConnect.Core.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace SportConnect.Core.ViewModels.MainApplications.Normal.SportEvents.AddSportEvent
{
    public class AddSportEventViewModel : BaseViewModel
    {
        private readonly UserService _userService;
        private readonly SportTypeService _sportTypeService;

        public string EventName { get; set; }
        public DateTime EventStartDate { get; set; }
        public DateTime EventStartTime { get; set; }
        public DateTime EventEndDate { get; set; }
        public DateTime EventEndTime { get; set; }
        public SportType SportTypeItem { get; set; }
        public ObservableCollection<SportType> SportTypeList { get; set; }
        public string Street { get; set; }
        public int HouseNumber { get; set; }
        public string ZipCode { get; set; }
        public string CityName { get; set; }
        public bool IsEventTypeSwitched { get; set; }
        public int MinimumNumberOfParticipants { get; set; }
        public int MaximumNumberOfParticipants { get; set; }
        public SportSkillLevel ProposedSportSkillLevel { get; set; }
        public List<SportSkillLevel> SportSkillLevelList { get; set; } = Enum.GetValues(typeof(SportSkillLevel)).Cast<SportSkillLevel>().ToList();

        public IMvxAsyncCommand SaveEvent =>
           new MvxAsyncCommand(async () => { await TryToSaveSportEvent(); });

        public AddSportEventViewModel(
            IMvxNavigationService navigationService,
                            SportTypeService sportTypeService,
                            UserService userService)
            : base(navigationService)
        {
            _sportTypeService = sportTypeService;
            _userService = userService;
            SportTypeList = new ObservableCollection<SportType>();
            FillSportTypeList().GetAwaiter();

            EventStartDate = DateTime.Today;
            EventEndDate = EventStartDate;
            EventStartTime = DateTime.Now;
            EventEndTime = DateTime.Now;
            EventEndDate.AddHours(2);
            IsEventTypeSwitched = true;
            ProposedSportSkillLevel = SportSkillLevelList.First();
        }

        private async Task FillSportTypeList()
        {
            var sportTypeList = await _sportTypeService.GetSportTypes();

            foreach (var sportType in sportTypeList)
            {
                SportTypeList.Add(sportType);
            }

            if (SportTypeList.Any())
            {
                SportTypeItem = SportTypeList.First();
            }
        }

        private async Task TryToSaveSportEvent()
        {
            //throw new NotImplementedException();
        }
    }
}
