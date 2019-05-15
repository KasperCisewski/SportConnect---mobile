using MvvmCross.Forms.Views;
using SportConnect.Core.ViewModels.MainApplications.Admin.UsersList;

namespace SportConnect.Core.View.MainApplications.Admin.UsersList
{
    public partial class UsersListView : MvxContentPage<UsersListViewModel>
    {
        public UsersListView()
        {
            InitializeComponent();
        }

        private void MenuItem_Clicked(object sender, System.EventArgs e)
        {

        }

        private void ListView_ItemTapped(object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {

        }
    }
}