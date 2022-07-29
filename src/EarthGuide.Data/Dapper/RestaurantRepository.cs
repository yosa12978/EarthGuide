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
    public class RestaurantRepository : IRestaurantRepository
    {
        private readonly IDbConnectionFactory connectionFactory;
        public RestaurantRepository(IDbConnectionFactory connectionFactory)
        {
            this.connectionFactory = connectionFactory;
        } 
        public async Task Create(Restaurant entity)
        {
            var db = connectionFactory.Connect();
            await db.ExecuteAsync(@"INSERT INTO Restaurants VALUES(
                @Id, @Name, @Desc, @Latitude, @Longitude, @IsActive, @Date
            )", entity);
        }

        public async Task Delete(string id)
        {
            var db = connectionFactory.Connect();
            await db.ExecuteAsync(@"DELETE FROM Restaurants WHERE Id = @Id", new { Id = id });
        }

        public async Task<IEnumerable<Restaurant>> GetAll()
        {
            var db = connectionFactory.Connect();
            return await db.QueryAsync<Restaurant>("SELECT * FROM Restaurants ORDER BY Date DESC");
        }

        public async Task<Restaurant> GetById(string id)
        {
            var db = connectionFactory.Connect();
            return await db.QueryFirstOrDefaultAsync<Restaurant>(
                "SELECT * FROM Restaurants WHERE Id = @Id LIMIT 1", new { Id = id });
        }

        public async Task Update(Restaurant entity)
        {
            var db = connectionFactory.Connect();
            await db.ExecuteAsync(@"UPDATE Restaurants 
            SET Name = @Name, Desc = @Desc, Latitude = @Latitude, Longitude = @Longitude, IsActive = @IsActive 
            WHERE Id = @Id", entity);
        }
    }
}
