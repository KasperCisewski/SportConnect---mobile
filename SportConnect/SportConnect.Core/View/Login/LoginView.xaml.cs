using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Forms.Presenters.Attributes;
using MvvmCross.Forms.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SportConnect.Core.View.Login
{
    [MvxMasterDetailPagePresentation]
    public partial class LoginView : MvxContentPage
    {
		public LoginView ()
		{
			InitializeComponent ();
		}
	}
}