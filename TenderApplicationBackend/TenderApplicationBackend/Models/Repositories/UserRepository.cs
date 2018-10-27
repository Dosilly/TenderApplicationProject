using ServiceStack.OrmLite;
using TenderApplicationBackend.Models.Entities;

namespace TenderApplicationBackend.Models.Repositories
{
    public class UserRepository
    {
        private readonly ConnectionFactory _connectionFactory;

        public UserRepository(ConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public void SaveUser(User user)
        {
            using (var connection = _connectionFactory.GetConnection())
            {
                connection.Save(user);
            }
        }
    }
}
