using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServiceStack.OrmLite;
using TenderApplicationBackend.Models.Entities;

namespace TenderApplicationBackend.Models.Repositories
{
   
    public class ReqgroupRepository
    {
        private readonly ConnectionFactory _connectionFactory;

        public ReqgroupRepository(ConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public void AddToGroup(List<Requirement_group> reqGroupList)
        {
            using (var connection = _connectionFactory.GetConnection())
            {
                try
                {
                    connection.InsertAll(reqGroupList);
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
