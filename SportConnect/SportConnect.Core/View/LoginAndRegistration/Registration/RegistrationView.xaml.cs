using System.Threading.Tasks;
using MvvmCross.Forms.Views;
using SportConnect.Core.ViewModels.LoginAndRegistration.Registration;
using Xamarin.Forms;

namespace SportConnect.Core.View.LoginAndRegistration.Registration
{
    public partial class RegistrationView : MvxContentPage<RegistrationViewModel>
    {
        public RegistrationView()
        {
            InitializeComponent();
        }

        private async void EmailOnTextChanged(object sender, TextChangedEventArgs e)
        {
            await ViewModel.ValidateEmail();
        }

        private async void LoginOnTextChanged(object sender, TextChangedEventArgs e)
        {
            await ViewModel.ValidateLogin();
        }

        private async void PasswordOnTextChanged(object sender, TextChangedEventArgs e)
        {
            await ViewModel.ValidatePassword();
        }

        private async void RepeatedPasswordOnTextChanged(object sender, TextChangedEventArgs e)
        {
            await ViewModel.ValidateRepeatedPassword();
        }
    }
}