using System.Data;
using Microsoft.Extensions.Configuration;
using ServiceStack.OrmLite;

namespace TenderApplicationBackend.Models
{
    public class ConnectionFactory
    {
        private readonly IConfiguration _configuration;

        public ConnectionFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IDbConnection GetConnection()
        {
            var database = _configuration["Configuration:Database"];
            var connectionString = _configuration.GetConnectionString(database);

            var connection =
                new OrmLiteConnectionFactory(connectionString, SqlServerDialect.Provider).OpenDbConnection();
            connection.Open();

            return connection;
        }
    }
}