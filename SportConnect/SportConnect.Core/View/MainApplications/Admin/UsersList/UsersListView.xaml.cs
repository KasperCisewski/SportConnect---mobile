using MvvmCross.Forms.Views;
using SportConnect.Core.ViewModels.MainApplications.Admin.UsersList;
using Xamarin.Forms;

namespace SportConnect.Core.View.MainApplications.Admin.UsersList
{
    public partial class UsersListView : MvxContentPage<UsersListViewModel>
    {
        public UsersListView()
        {
            InitializeComponent();
        }

        private void Button_Clicked_Edit_User(object sender, SelectedItemChangedEventArgs e)
        {
            //TODO:wrong data binding

            ViewModel.GoToEditUserView().GetAwaiter();
        }

        private void Button_Clicked_Delete_User(object sender, System.EventArgs e)
        {
            ViewModel.DeleteUser().GetAwaiter();
        }
    }
}