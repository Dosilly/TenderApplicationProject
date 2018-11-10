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

        public List<Workhour> SelectWorkhoursByRequirementId(int id)
        {
            using (var connection = _connectionFactory.GetConnection())
            {
                try
                {
                    return connection.Select<Workhour>(p => p.ReqId == id);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
        }

        public void AddWorkhour(Workhour workhour)
        {
            using (var connection = _connectionFactory.GetConnection())
            {
                try
                {
                    connection.Insert(workhour);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
        }

        public void EditWorkhour(Workhour workhour)
        {
            using (var connection = _connectionFactory.GetConnection())
            {
                try
                {
                    connection.UpdateOnly(workhour,
                        u => new{u.Workhours},
                        p => p.Id == workhour.Id);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
        }

        public void DeleteWorkhour(int id)
        {
            using (var connection = _connectionFactory.GetConnection())
            {
                try
                {
                    connection.DeleteById<Workhour>(id);
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
