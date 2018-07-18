using SQLite;

namespace Orderbon
{
    public interface ISQLiteDb
    {
        SQLiteAsyncConnection GetConnection();
    }
}

