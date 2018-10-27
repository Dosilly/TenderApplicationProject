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
                connection.Save(employee);
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
