using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EarthGuide.Core.Domain;

namespace EarthGuide.Core.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User> GetByUsername(string username);
        Task<User> GetByUsernameAndPassword(string username, string password);
        Task<bool> IsUsernameTaken(string username);
        Task<bool> IsUserExist(string username, string password);
    }
}
