using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using MvvmCross.Commands;
using SportConnect.Core.Model.Profile;
using SportConnect.Core.Model.SportType;
using SportConnect.Core.Services.User;
using SportConnect.Core.ViewModels.Base;

namespace SportConnect.Core.ViewModels.MainApplications.Admin.UsersList
{
    public class EditUserViewModel : BaseViewModel<EditUserModel>
    {
        private readonly UserService _userService;
        private EditUserModel _editUserModel;

        public string Login { get; set; }
        public string Email { get; set; }
        public SportType SportTypeItem { get; set; }
        public ObservableCollection<SportType> SportTypeList { get; set; }
        public EditUserViewModel(UserService userService)
        {
            _userService = userService;
        }

        public override void Prepare(EditUserModel editUserModel)
        {
            _editUserModel = editUserModel;
            FillEditFormForUser(_editUserModel.UserId).GetAwaiter();
        }

        private async Task FillEditFormForUser(Guid userId)
        {
            var userProfileModel = await _userService.GetUserProfileData(userId);

            Login = userProfileModel.Login;
            Email = userProfileModel.Email;

            if (SportTypeList.Any())
            {
                SportTypeItem = SportTypeList
                    .FirstOrDefault(st => st.Id == userProfileModel.FacouriteSportTypeId);
            }
        }
        public IMvxAsyncCommand UpdateUserProfile =>
     new MvxAsyncCommand(async () =>
     {
         await _userService.UpdateProfileData(new UserProfileModel
         {
             UserId = _editUserModel.UserId,
             Login = this.Login,
             Email = this.Email,
             FacouriteSportTypeId = SportTypeItem.Id
         });
     });
    }
}
