using ServiceStack.OrmLite;
using TenderApplicationBackend.Models.Entities;

namespace TenderApplicationBackend.Models.Repositories
{
    public class TestRepository
    {
        private readonly ConnectionFactory _connectionFactory;

        public TestRepository(ConnectionFactory connectionFactory)
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
