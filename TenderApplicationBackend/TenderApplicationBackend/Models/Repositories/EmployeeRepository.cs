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
    }
}
