
using Android.App;
using SportConnect.Core.Services.ViewHistory;
using MvvmCross.Droid.Support.V7.AppCompat;
using MvvmCross.Platforms.Android;
using MvvmCross;
using SportConnect.Core.Services.Logger;
using MvvmCross.Forms.Platforms.Android.Views;

namespace SportConnect.Droid.Services
{
    public class ViewHistoryService : IViewHistoryService
    {
        private readonly ILoggerService _loggerService;

        public ViewHistoryService(ILoggerService loggerService)
        {
            _loggerService = loggerService;
        }

        public void ClearHistory()
        {
            var context = Mvx.IoCProvider.Resolve<IMvxAndroidCurrentTopActivity>().Activity;

            if (context is MvxFormsAppCompatActivity compatContext)
            {
               
                //compatContext.FinishActivity();
                compatContext.SupportFragmentManager.ExecutePendingTransactions();
                compatContext.SupportFragmentManager.PopBackStackImmediate(null, (int)PopBackStackFlags.Inclusive);
                //compatContext.Finish();
                //compatContext.OnBackPressed(
            }
            else
            {
                _loggerService.LogInfo("Context is not compat activity in history service");
            }
        }
    }
}