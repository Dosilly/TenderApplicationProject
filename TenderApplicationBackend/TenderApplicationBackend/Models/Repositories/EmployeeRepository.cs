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

        public void DeleteEmployee(int userId)
        {
            using (var connection = _connectionFactory.GetConnection())
            {
                try
                {
                    connection.Delete<Employee>(e => e.UserId == userId);
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
                try
                {
                    return connection.Select<Employee>();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
        }

        public Employee SelectEmployeeById(int id)
        {
            using (var connection = _connectionFactory.GetConnection())
            {
                try
                {
                    return connection.SingleById<Employee>(id);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
        }

        public Employee SelectEmployeeByUserId(int id)
        {
            using (var connection = _connectionFactory.GetConnection())
            {
                try
                {
                    return connection.Single<Employee>(p => p.UserId == id);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
        }

        public void EditEmployee(Employee employee)
        {
            using (var connection = _connectionFactory.GetConnection())
            {
                try
                {
                    connection.Update(employee, p => p.UserId == employee.UserId);
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