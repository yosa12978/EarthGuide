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
    public class SightplaceRepository : ISightplaceRepository
    {
        private readonly IDbConnectionFactory connectionFactory;
        public SightplaceRepository(IDbConnectionFactory connectionFactory)
        {
            this.connectionFactory = connectionFactory;
        }

        public async Task Create(Sightplace entity)
        {
            var db = connectionFactory.Connect();
            await db.ExecuteAsync(@"INSERT INTO Sightplaces VALUES(
                @Id, @Name, @Desc, @Latitude, @Longitude, @IsActive, @Date            
            )", entity);
        }

        public async Task Delete(string id)
        {
            var db = connectionFactory.Connect();
            await db.ExecuteAsync("DELETE FROM Sightplaces WHERE Id = @Id", new {Id = id});
        }

        public async Task<IEnumerable<Sightplace>> GetAll()
        {
            var db = connectionFactory.Connect();
            return await db.QueryAsync<Sightplace>("SELECT * FROM Sightplaces ORDER BY Date DESC");
        }

        public async Task<Sightplace> GetById(string id)
        {
            var db = connectionFactory.Connect();
            return await db.QueryFirstOrDefaultAsync<Sightplace>(
                "SELECT * FROM Sightplaces WHERE Id = @Id LIMIT 1", new { Id = id });
        }

        public async Task Update(Sightplace entity)
        {
            var db = connectionFactory.Connect();
            await db.ExecuteAsync(@"UPDATE Sightplaces 
            SET Name = @Name, Desc = @Desc, Latitude = @Latitude, Longitude = @Longitude, IsActive = @IsActive
            WHERE Id = @Id", entity);
        }
    }
}
