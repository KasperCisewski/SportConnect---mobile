using Xamarin.Essentials;

namespace SportConnect.Core.Services.Settings
{
    public class AppSettings : IAppSettings
    {
        public const string SuperNumberKey = "SuperNumberKey";
        public const int SuperNumberDefaultValue = 1;

        //private static ISettings AppSetting => CrossSettings.Current;
        private const string SettingsApiUrlKey = nameof(SettingsApiUrlKey);

        public int SuperNumber
        {
            get { return Preferences.Get(SuperNumberKey, SuperNumberDefaultValue); }
            set { Preferences.Set(SuperNumberKey, value); }
        }

        public SettingsModel GetSettings()
        {
            return new SettingsModel
            {
              //  ApiUrl = AppSetting.GetValueOrDefault(SettingsApiUrlKey, StaticAppSettings.ApiUrl),
                //ApiSecret = StaticAppSettings.ApiSecret,
                //SelectedLocale = AppSetting.GetValueOrDefault(SettingsSelectedLocale, StaticAppSettings.DefaultLocale)
            };
        }
    }

    public class SettingsModel
    {
        public string ApiUrl { get; set; }
        public string ApiSecret { get; set; }
        public string SelectedLocale { get; set; }
    }
}
