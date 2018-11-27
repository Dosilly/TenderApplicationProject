using System;
using System.Data;
using System.Net;
using Microsoft.Extensions.Configuration;
using ServiceStack.OrmLite;

namespace TenderApplicationBackend.Models
{
    public class ConnectionFactory
    {
        private readonly IConfiguration _configuration;
        public static string DockerHostMachineIpAddress => Dns.GetHostAddresses(new Uri("http://docker.for.win.localhost").Host)[0].ToString();

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