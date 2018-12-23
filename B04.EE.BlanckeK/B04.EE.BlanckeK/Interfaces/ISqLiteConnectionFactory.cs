using SQLite;

namespace B04.EE.BlanckeK.Interfaces
{
    public interface ISqLiteConnectionFactory
    {
        SQLiteConnection CreateConnection(string databaseFileName);
    }
}
