using System;
using System.Threading.Tasks;
using MvvmCross.Forms.Views;
using SportConnect.Core.ViewModels.MainApplications.Normal.SportEvents;

namespace SportConnect.Core.View.MainApplications.Normal.SportEvents
{
    public partial class SportEventsView : MvxContentPage<SportEventsViewModel>
    {
        public SportEventsView()
        {
            InitializeComponent();
        }

        private void ListView_ItemSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            ViewModel.GoToSportEventView().GetAwaiter();
        }
    }
}