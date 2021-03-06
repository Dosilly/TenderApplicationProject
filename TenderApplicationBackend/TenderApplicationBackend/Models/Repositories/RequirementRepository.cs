﻿using System;
using System.Collections.Generic;
using ServiceStack.OrmLite;
using TenderApplicationBackend.Models.Entities;

namespace TenderApplicationBackend.Models.Repositories
{
    public class RequirementRepository: IRequirementRepository
    {
        private readonly ConnectionFactory _connectionFactory;

        public RequirementRepository(ConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        public List<Requirement> SelectAllRequirements()
        {
            using (var connection = _connectionFactory.GetConnection())
            {
                try
                {
                    return connection.Select<Requirement>();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
        }

        public void AddRequirement(Requirement requirement)
        {
            using (var connection = _connectionFactory.GetConnection())
            {
                try
                {
                    connection.Insert(requirement);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
        }

        public void DeleteRequirement(int id)
        {
            using (var connection = _connectionFactory.GetConnection())
            {
                try
                {
                    connection.DeleteById<Requirement>(id);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
        }

        public void EditRequirement(Requirement requirement)
        {
            using (var connection = _connectionFactory.GetConnection())
            {
                try
                {
                    connection.UpdateOnly(requirement,
                        u => new {u.Description,u.Explanation,u.Name},
                        p => p.Id == requirement.Id);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
        }

        public List<Requirement> SelectRequirementsByTenderId(int id)
        {
            using (var connection = _connectionFactory.GetConnection())
            {
                try
                {
                    return connection.Select<Requirement>(p => p.TenderId == id);
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
