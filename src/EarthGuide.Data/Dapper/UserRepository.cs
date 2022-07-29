using EarthGuide.Core.Domain;
using EarthGuide.Core.Interfaces;
using EarthGuide.Data.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace EarthGuide.Data.Dapper
{
    public class UserRepository : IUserRepository
    {
        private readonly IDbConnectionFactory connectionFactory;
        public UserRepository(IDbConnectionFactory connectionFactory)
        {
            this.connectionFactory = connectionFactory;
        }

        public async Task Create(User entity)
        {
            var db = connectionFactory.Connect();
            await db.ExecuteAsync(@"INSERT INTO Usrs VALUES(
                @Id, @Username, @Password, @CreationTime, @IsActive, false
            )", entity);
        }
        
        public async Task Delete(string id)
        {
            var db = connectionFactory.Connect();
            await db.ExecuteAsync("DELETE FROM Usrs WHERE Id = @Id", new { Id = id });
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            var db = connectionFactory.Connect();
            return await db.QueryAsync<User>("SELECT * FROM Usrs ORDER BY Username ASC");
        }

        public async Task<User> GetById(string id)
        {
            var db = connectionFactory.Connect();
            return await db.QueryFirstOrDefaultAsync<User>(
                "SELECT * FROM Usrs WHERE Id = @Id LIMIT 1", new {Id = id});
        }

        public async Task<User> GetByUsername(string username)
        {
            var db = connectionFactory.Connect();
            return await db.QueryFirstOrDefaultAsync<User>(
                "SELECT * FROM Usrs WHERE Username = @Username LIMIT 1",
                new { Username = username });
        }

        public async Task<User> GetByUsernameAndPassword(string username, string password)
        {
            var db = connectionFactory.Connect();
            return await db.QueryFirstOrDefaultAsync<User>(
                "SELECT * FROM Usrs WHERE Username = @Username ANS Password = @Password LIMIT 1", 
                new { Username = username, Password = password });
        }

        public async Task<bool> IsUserExist(string username, string password)
        {
            var db = connectionFactory.Connect();
            return await db.QueryFirstOrDefaultAsync<User>(
                "SELECT * FROM Usrs WHERE Username = @Username ANS Password = @Password LIMIT 1",
                new { Username = username, Password = password }) != null;
        }

        public async Task<bool> IsUsernameTaken(string username)
        {
            var db = connectionFactory.Connect();
            return await db.QueryFirstOrDefaultAsync<User>(
                "SELECT * FROM Usrs WHERE Username = @Username LIMIT 1",
                new { Username = username }) != null;
        }

        public async Task Update(User entity)
        {
            var db = connectionFactory.Connect();
            await db.ExecuteAsync(@"UPDATE Usrs 
                SET Username = @Username, Password = @Password, IsActive = @IsActive
                WHERE Id = @Id LIMIT 1",
                entity);
        }
    }
}
