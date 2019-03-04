﻿// ---------------------------------------------------------------
// <author>Paul Datsyuk</author>
// <url>https://www.linkedin.com/in/pauldatsyuk/</url>
// ---------------------------------------------------------------

using MvvmCross.Forms.Presenters.Attributes;
using MvvmCross.Forms.Views;

namespace SportConnect.Core.Pages
{
    [MvxMasterDetailPagePresentation]
    public partial class MainPage : MvxContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
    }
}