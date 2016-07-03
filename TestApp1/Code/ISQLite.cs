using SQLite;

namespace TestApp1.Code
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
}