using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using SportConnect.Core.Model.Profile;
using SportConnect.Core.Model.SportType;
using SportConnect.Core.Services.SportType;
using SportConnect.Core.Services.User;
using SportConnect.Core.ViewModels.Base;

namespace SportConnect.Core.ViewModels.MainApplications.Normal.Profile
{
    public class ProfileViewModel : BaseViewModel
    {
        private readonly SportTypeService _sportTypeService;
        private readonly UserService _userService;


        public string Login { get; set; }
        public string Email { get; set; }

        private Guid _userId;
        public SportType SportTypeItem { get; set; }
        public ObservableCollection<SportType> SportTypeList { get; set; }

        public ProfileViewModel(
            SportTypeService sportTypeService,
            UserService userService)
        {
            _sportTypeService = sportTypeService;
            _userService = userService;

            SportTypeList = new ObservableCollection<SportType>();

            FillSportTypeList().GetAwaiter();
            Task.WaitAll();
            GetUserAndFillUserProfileData().GetAwaiter();
        }

        private async Task GetUserAndFillUserProfileData()
        {
            var userProfileModel = await _userService
                .GetUserProfileData();
            Login = userProfileModel.Login;
            Email = userProfileModel.Email;
            _userId = userProfileModel.UserId;

            if (SportTypeList.Any())
            {
                SportTypeItem = SportTypeList
                    .FirstOrDefault(st => st.Id == userProfileModel.FacouriteSportTypeId);
            }
        }


        private async Task FillSportTypeList()
        {
            var sportTypeList = await _sportTypeService.GetSportTypes();

            foreach (var sportType in sportTypeList)
            {
                SportTypeList.Add(sportType);
            }
        }

        public IMvxAsyncCommand UpdateUserProfile =>
       new MvxAsyncCommand(async () =>
       {
           await _userService.UpdateProfileData(new UserProfileModel
           {
               UserId = _userId,
               Login = this.Login,
               Email = this.Email,
               FacouriteSportTypeId = SportTypeItem.Id
           });
       });
    }
}
