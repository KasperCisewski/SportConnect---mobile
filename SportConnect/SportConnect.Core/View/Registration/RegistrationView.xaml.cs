using MvvmCross.Forms.Views;
using SportConnect.Core.ViewModels.Registration;
using Xamarin.Forms;

namespace SportConnect.Core.View.Registration
{
    public partial class RegistrationView : MvxContentPage<RegistrationViewModel>
    {
        public RegistrationView()
        {
            InitializeComponent();

        }

        private void EmailOnTextChanged(object sender, TextChangedEventArgs e)
        {
            ViewModel.ValidateEmail();
        }

        private void LoginOnTextChanged(object sender, TextChangedEventArgs e)
        {
            ViewModel.ValidateLogin();
        }

        private void PasswordOnTextChanged(object sender, TextChangedEventArgs e)
        {
            ViewModel.ValidatePassword();
        }

        private void RepeatedPasswordOnTextChanged(object sender, TextChangedEventArgs e)
        {
            ViewModel.ValidateRepeatedPassword();
        }
    }
}