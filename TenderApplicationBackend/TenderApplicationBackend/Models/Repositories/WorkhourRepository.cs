using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServiceStack.OrmLite;
using TenderApplicationBackend.Models.Entities;

namespace TenderApplicationBackend.Models.Repositories
{
    public class WorkhourRepository
    {
        private readonly ConnectionFactory _connectionFactory;

        public WorkhourRepository(ConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        public List<Workhour> SelectAllWorkhours()
        {
            using (var connection = _connectionFactory.GetConnection())
            {
                try
                {
                    return connection.Select<Workhour>();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
        }
    }
}
