using SportConnect.Core.Services.SqlLite;
using SportConnect.Droid.Services.SqlLite;
using SQLite;

[assembly: Xamarin.Forms.Dependency(typeof(SqlLiteService))]
namespace SportConnect.Droid.Services.SqlLite
{
    public class SqlLiteService : ISqlLiteService
    {
        public SQLiteConnection GetConnection()
        {
            var dbName = "sportConnect.sqlite";
            var dbPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData);
            var path = System.IO.Path.Combine(dbPath, dbName);
            return new SQLiteConnection(path);
        }
    }
}