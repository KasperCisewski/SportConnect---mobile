using System;
using System.IO;
using SportConnect.Core.Services.SqlLite;
using SportConnect.iOS.Services.SqlLite;
using SQLite;
using Xamarin.Forms;

[assembly: Dependency(typeof(SqlLiteService))]
namespace SportConnect.iOS.Services.SqlLite
{
    public class SqlLiteService : ISqlLiteService
    {

        public SQLiteConnection GetConnection()
        {
            var dbName = "sportConnectionDatabase.sqlite";
            var dbPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var libraryPath = Path.Combine(dbPath, "..", "Library");
            var path = Path.Combine(libraryPath, dbName);
            return new SQLiteConnection(path);
        }
    }
}