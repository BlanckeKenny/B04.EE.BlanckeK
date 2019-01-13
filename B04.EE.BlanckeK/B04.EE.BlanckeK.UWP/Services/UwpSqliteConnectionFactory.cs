using System.IO;
using Windows.Storage;
using B04.EE.BlanckeK.Interfaces;
using SQLite;
using Xamarin.Forms;


[assembly:Dependency(typeof(B04.EE.BlanckeK.UWP.Services.UwpSqliteConnectionFactory))]

namespace B04.EE.BlanckeK.UWP.Services
{
    internal class UwpSqliteConnectionFactory : ISqLiteConnectionFactory
    {
        public SQLiteConnection CreateConnection(string databaseFileName)
        {
            var path = ApplicationData.Current.LocalFolder.Path;
            path = Path.Combine(path, databaseFileName);
            return new SQLiteConnection(path,false);
        }
    }
}
