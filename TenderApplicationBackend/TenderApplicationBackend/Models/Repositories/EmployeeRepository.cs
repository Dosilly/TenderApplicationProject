using System;
using System.Collections.Generic;
using ServiceStack.OrmLite;
using TenderApplicationBackend.Models.Entities;

namespace TenderApplicationBackend.Models.Repositories
{
    public class EmployeeRepository
    {
        private readonly ConnectionFactory _connectionFactory;

        public EmployeeRepository(ConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
            

        public void SaveEmployee(Employee employee)
        {
            using (var connection = _connectionFactory.GetConnection())
            {
                
                try
                {
                    connection.Save(employee);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
        }
        public List<Employee> SelectAllEmployees()
        {
            using (var connection = _connectionFactory.GetConnection())
            {
                return connection.Select<Employee>();
            }
        }
    }
}
