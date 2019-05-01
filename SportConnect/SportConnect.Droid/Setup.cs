// ---------------------------------------------------------------
// <author>Paul Datsyuk</author>
// <url>https://www.linkedin.com/in/pauldatsyuk/</url>
// ---------------------------------------------------------------

using MvvmCross;
using MvvmCross.Forms.Platforms.Android.Core;
using MvvmCross.Logging;
using Serilog;
using SportConnect.Core.Services.Logger;
using SportConnect.Droid.Services;
using SportConnect.Droid.Services.SqlLite;

namespace SportConnect.Droid
{
    public class Setup : MvxFormsAndroidSetup<Core.MvxApp, Core.FormsApp>
    {
        protected override void InitializeFirstChance()
        {
            base.InitializeFirstChance();

            Mvx.IoCProvider.RegisterSingleton<Core.Services.ILocalizeService>(() => new Services.LocalizeService());
            Mvx.IoCProvider.RegisterType<Core.Services.ViewHistory.IViewHistoryService>(() => new ViewHistoryService(Mvx.IoCProvider.Resolve<ILoggerService>()));
            Mvx.IoCProvider.RegisterType<Core.Services.SqlLite.ISqlLiteService>(() => new SqlLiteService());
        }

        public override MvxLogProviderType GetDefaultLogProviderType() => MvxLogProviderType.Serilog;

        protected override IMvxLogProvider CreateLogProvider()
        {
            Log.Logger = new LoggerConfiguration()
                        .MinimumLevel.Debug()
                        .WriteTo.AndroidLog()
                        .CreateLogger();

            return base.CreateLogProvider();
        }
    }
}