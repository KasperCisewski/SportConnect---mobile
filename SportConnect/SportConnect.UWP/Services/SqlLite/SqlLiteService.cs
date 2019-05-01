using SportConnect.Core.Services.SqlLite;
using SportConnect.UWP.Services.SqlLite;
using SQLite;
using System.IO;
using Windows.Storage;

[assembly: Xamarin.Forms.Dependency(typeof(SqlLiteService))]
namespace SportConnect.UWP.Services.SqlLite
{
    public class SqlLiteService : ISqlLiteService
    {
        public SQLiteConnection GetConnection()
        {
            var dbName = "sportConnectionDatabase.db3";
            var path = Path.Combine(ApplicationData.Current.LocalFolder.Path, dbName);
            return new SQLiteConnection(path);
        }
    }
}
