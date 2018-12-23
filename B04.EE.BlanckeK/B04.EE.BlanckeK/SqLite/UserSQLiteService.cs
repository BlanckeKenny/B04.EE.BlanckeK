using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using B04.EE.BlanckeK.Interfaces;
using B04.EE.BlanckeK.Models;

namespace B04.EE.BlanckeK.SqLite
{
    public class UserSqLiteService : SqLiteServiceBase, IUserService
    {
        public async Task SaveUser(User user)
        {
            await Task.Run(() => {
                try
                {
                    Connection.InsertOrReplace(user);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            });
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await Task.Run<List<User>>( () => Connection.Table<User>().OrderByDescending(a => a.Level).OrderByDescending(a => a.Score).ToList());
        }

        public async Task DeleteUser(User user)
        {
            await Task.Run(() => {
                try
                {
                    Connection.Delete(user);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            });
        }
    }
}
