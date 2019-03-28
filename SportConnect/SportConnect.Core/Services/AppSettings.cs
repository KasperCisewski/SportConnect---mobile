﻿using Xamarin.Essentials;

namespace SportConnect.Core.Services
{
    public class AppSettings : IAppSettings
    {
        public const string SuperNumberKey = "SuperNumberKey";
        public const int SuperNumberDefaultValue = 1;

        public int SuperNumber
        {
            get { return Preferences.Get(SuperNumberKey, SuperNumberDefaultValue); }
            set { Preferences.Set(SuperNumberKey, value); }
        }
    }
}
