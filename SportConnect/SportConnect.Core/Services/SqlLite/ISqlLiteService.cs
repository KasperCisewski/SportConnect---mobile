using SQLite;
namespace SportConnect.Core.Services.SqlLite
{
    public interface ISqlLiteService
    {
        SQLiteConnection GetConnection();
    }
}
