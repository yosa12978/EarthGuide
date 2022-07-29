using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EarthGuide.Data.Db
{
    public class DatabaseInitializer
    {
        private readonly IDbConnectionFactory connectionFactory;
        public DatabaseInitializer(IDbConnectionFactory connectionFactory)
        {
            this.connectionFactory = connectionFactory;
        }
        public async Task Initialize()
        {
            var db = connectionFactory.Connect();

            await db.ExecuteAsync("CREATE TABLE IF NOT EXIST Usrs ");
        }
    }
}
