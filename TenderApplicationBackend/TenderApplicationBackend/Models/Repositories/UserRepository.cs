using System;
using System.Collections.Generic;
using ServiceStack;
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
                try
                {
                    connection.Save(user);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
        }

        public void DeleteUser(int userId)
        {
            using (var connection = _connectionFactory.GetConnection())
            {
                try
                {
                    connection.DeleteById<User>(userId);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
        }

        public void EditUser(User user)
        {
            using (var connection = _connectionFactory.GetConnection())
            {
                if (user.UserPass.IsNullOrEmpty()) // if password is empty, don't update it
                    connection.UpdateOnly(user,
                        p => new {p.Role, p.Username},
                        u => u.Id == user.Id);
                else
                    connection.Update(user, p => p.Id == user.Id);
            }
        }

        public List<User> SelectAllUsers()
        {
            using (var connection = _connectionFactory.GetConnection())
            {
                return connection.Select<User>();
            }
        }

        public User SelectUserByUsername(string username)
        {
            using (var connection = _connectionFactory.GetConnection())
            {
                return connection.Single<User>(x => x.Username == username);
            }
        }
    }
}