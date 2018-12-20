using System;
using System.Collections.Generic;
using ServiceStack.OrmLite;
using TenderApplicationBackend.Models.Entities;

namespace TenderApplicationBackend.Models.Repositories
{
    public class GroupRepository : IGroupRepository
    {
        private readonly ConnectionFactory _connectionFactory;

        public GroupRepository(ConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        public List<Group> SelectAllGroups()
        {
            using (var connection = _connectionFactory.GetConnection())
            {
                try
                {
                    return connection.Select<Group>();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
        }

        public List<Group> SelectGroupsByRequirementId(int id)
        {
            using (var connection = _connectionFactory.GetConnection())
            {
                var idList = new List<int>();
                var res = connection.Select<Requirement_group>(x => x.ReqId == id);

                foreach (var e in res)
                {
                    var i = e.GroupId;
                    idList.Add(i);
                }

                try
                {
                    return connection.Select<Group>(x => Sql.In(x.Id,idList));
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
        }

        public void AddGroup(Group group)
        {
            using (var connection = _connectionFactory.GetConnection())
            {
                try
                {
                    connection.Insert(group);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
        }

        public void EditGroup(Group group)
        {
            using (var connection = _connectionFactory.GetConnection())
            {
                try
                {
                    connection.UpdateOnly(group,
                        u => new {u.Name,u.Workhours},
                        p => p.Id == group.Id);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
        }

        public void DeleteGroup(int id)
        {
            using (var connection = _connectionFactory.GetConnection())
            {
                try
                {
                    connection.DeleteById<Group>(id);
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
