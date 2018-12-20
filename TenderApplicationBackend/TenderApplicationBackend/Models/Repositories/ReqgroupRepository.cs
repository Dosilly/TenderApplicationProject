using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServiceStack.OrmLite;
using TenderApplicationBackend.Models.Entities;
using TenderApplicationBackend.Models.Interfaces;

namespace TenderApplicationBackend.Models.Repositories
{
   
    public class ReqgroupRepository : IReqgroupRepository
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

        public void DeleteFromGroup(int reqId, int groupId)
        {
            using (var connection = _connectionFactory.GetConnection())
            {
                try
                {
                    connection.Delete<Requirement_group>(p => p.ReqId == reqId && p.GroupId == groupId);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
        }

        public bool IsRequirementInGroup(int reqId)
        {
            using (var connection = _connectionFactory.GetConnection())
            {
                try
                {
                    return connection.Select<Requirement_group>(p => p.ReqId == reqId).Count > 0;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
        }

        public int GetGroupId(int reqId)
        {
            using (var connection = _connectionFactory.GetConnection())
            {
                try
                {
                    return connection.Single<Requirement_group>(p => p.ReqId == reqId).GroupId;
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
