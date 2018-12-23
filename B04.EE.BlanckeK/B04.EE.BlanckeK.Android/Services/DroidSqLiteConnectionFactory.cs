using B04.EE.BlanckeK.Interfaces;
using System;
using System.IO;
using SQLite;
using Xamarin.Forms;

[assembly: Dependency(typeof(B04.EE.BlanckeK.Droid.Services.DroidSqLiteConnectionFactory))]

namespace B04.EE.BlanckeK.Droid.Services
{
    internal class DroidSqLiteConnectionFactory : ISqLiteConnectionFactory
    {
        public SQLiteConnection CreateConnection(string databaseFileName)
        {

            string path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            path = Path.Combine(path, databaseFileName);

            return new SQLiteConnection(path, false);
/*            var platform = new SQLite.Net.Platform.XamarinAndroid.SQLitePlatformAndroid();
            var connection = new SQLite.Net.SQLiteConnection(platform, path, false);
            return connection;

            return new SQLiteConnection(
                new SQLitePlatformAndroid(),
                path,
                SQLiteOpenFlags.Create | SQLiteOpenFlags.ReadWrite,
                storeDateTimeAsTicks: false;*/
        }
    }
}