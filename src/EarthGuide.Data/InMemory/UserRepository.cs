using EarthGuide.Core.Domain;
using EarthGuide.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EarthGuide.Data.InMemory
{
    public class UserRepository : IUserRepository
    {
        List<User> users = new List<User>();

        public async Task Create(User user)
        {
            users.Add(user);
        }

        public async Task Delete(string id)
        {
            users.Remove(users.FirstOrDefault(x => x.Id == id));
        }

        public async Task<User> GetById(string id)
        {
            return users.FirstOrDefault(x => x.Id == id);
        }

        public async Task<User> GetByUsername(string username)
        {
            return users.FirstOrDefault(x => x.Username == username);
        }

        public async Task<User> GetByUsernameAndPassword(string username, string password)
        {
            return users.FirstOrDefault(x => x.Username == username && x.Password == password);
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return users;
        }

        public async Task<bool> IsUserExist(string username, string password)
        {
            return users.Any(x => x.Username == username && x.Password == password);
        }

        public async Task<bool> IsUsernameTaken(string username)
        {
            return users.Any(x => x.Username == username);
        }

        public async Task Update(string id, User user)
        {
            users[users.IndexOf(users.FirstOrDefault(x => x.Id == id))] = user;
        }
    }
}
