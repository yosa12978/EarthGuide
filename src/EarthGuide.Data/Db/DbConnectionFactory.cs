using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EarthGuide.Data.Db
{
    public interface IDbConnectionFactory
    {
        IDbConnection Connect();
    }

    public class SqliteConnectionFactory : IDbConnectionFactory
    {
        private readonly string connectionString;
        public SqliteConnectionFactory(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public IDbConnection Connect() 
        {
            IDbConnection connection = new SqliteConnection(connectionString);
            connection.Open();
            return connection;
        }
    }
}
