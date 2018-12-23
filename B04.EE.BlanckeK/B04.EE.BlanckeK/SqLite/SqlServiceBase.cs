using B04.EE.BlanckeK.Interfaces;
using B04.EE.BlanckeK.Models;
using SQLite;
using Xamarin.Forms;

namespace B04.EE.BlanckeK.SqLite
{
    public abstract class SqLiteServiceBase
    {
        protected readonly SQLiteConnection Connection;

        protected SqLiteServiceBase()
        {
            var connectionFactory = DependencyService.Get<ISqLiteConnectionFactory>();
            Connection = connectionFactory.CreateConnection(Constants.Constants.SqlDbName);
            try
            {
                Connection.Query<User>("select * from user");
            }
            catch
            {
                Connection.DropTable<User>();
                Connection.CreateTable<User>();
            }

        }
    }
}
