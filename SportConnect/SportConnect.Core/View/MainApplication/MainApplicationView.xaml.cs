using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Forms.Views;
using SportConnect.Core.ViewModels.MainApplication;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SportConnect.Core.View.MainApplication
{
    public partial class MainApplicationView : MvxTabbedPage<MainApplicationViewModel>
    {
        public MainApplicationView()
        {
            InitializeComponent();
        }
    }
}