using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Forms.Presenters.Attributes;
using MvvmCross.Forms.Views;
using SportConnect.Core.ViewModels.Login;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SportConnect.Core.View.Login
{
    public partial class LoginView : MvxContentPage<LoginViewModel>
    {
        public LoginView()
        {
            InitializeComponent();
        }
    }
}