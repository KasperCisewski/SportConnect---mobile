using Acr.UserDialogs;
using MvvmCross.Logging;
using MvvmCross.Navigation;
using SportConnect.Core.Data.Enums.SportSkillLevel;
using SportConnect.Core.Data.Enums.SportType;
using SportConnect.Core.Services.Settings;
using SportConnect.Core.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SportConnect.Core.ViewModels.MainApplications.Normal.SportEvents.AddSportEvent
{
    public class AddSportEventViewModel : BaseViewModel
    {
        private readonly IMvxLogProvider _mvxLogProvider;
        private readonly IAppSettings _settings;
        private readonly IUserDialogs _userDialogs;
        public AddSportEventViewModel(
            IMvxNavigationService navigationService,
                IMvxLogProvider mvxLogProvider,
            IAppSettings settings, IUserDialogs userDialogs) : base(navigationService)
        {
            _mvxLogProvider = mvxLogProvider;
            _settings = settings;
            _userDialogs = userDialogs;
        }

        public string EventName { get; set; }
        public DateTime EventStartDate { get; set; }
        public DateTime TodaysDate { get; set; } = new DateTime();
        public DateTime EventEndDate { get; set; }
        public SportType SportTypeEvent { get; set; }
        public List<SportType> SportTypeList { get; set; }
        public string Street { get; set; }
        public int HouseNumber { get; set; }
        public string ZipCode { get; set; }
        public string CityName { get; set; }
        public bool IsEventTypeSwitched { get; set; }
        public int MinimumNumberOfParticipants { get; set; }
        public int MaximumNumberOfParticipants { get; set; }
        public SportSkillLevel ProposedSportSkillLevel { get; set; }
        public List<SportSkillLevel> SportSkillLevelList { get; set; } = Enum.GetValues(typeof(SportSkillLevel)).Cast<SportSkillLevel>().ToList();

    }
}
