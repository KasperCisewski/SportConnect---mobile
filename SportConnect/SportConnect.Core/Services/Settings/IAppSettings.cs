
namespace SportConnect.Core.Services.Settings
{
    public interface IAppSettings
    {
        int SuperNumber { get; set; }
        SettingsModel GetSettings();
    }
}