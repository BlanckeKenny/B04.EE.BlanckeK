using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using B04.EE.BlanckeK.Models;

namespace B04.EE.BlanckeK.Interfaces
{
    public interface IUserService
    {
        Task SaveUser(User user);
        Task<List<User>> GetAllUsers();
        Task DeleteUser(User user);
    }
}
