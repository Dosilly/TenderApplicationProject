using System.Collections.Generic;
using ServiceStack.OrmLite;
using TenderApplicationBackend.Models.Dtos;
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

        public List<User> SelectAllUsers()
        {
            using (var connection = _connectionFactory.GetConnection())
            {
                return connection.Select<User>();
            }
        }

        public User SelectUserByUsername(UserEmployeeRequest user)
        {
            using (var connection = _connectionFactory.GetConnection())
            {
                return connection.Single<User>(x => x.Username == user.Username);
            }
        }

    }
}
