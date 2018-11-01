﻿using System;
using System.Collections.Generic;
using ServiceStack.OrmLite;
using TenderApplicationBackend.Models.Entities;

namespace TenderApplicationBackend.Models.Repositories
{
    public class TenderRepository
    {
        private readonly ConnectionFactory _connectionFactory;

        public TenderRepository(ConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public void AddTender(Tender tender)
        {
            using (var connection = _connectionFactory.GetConnection())
            {
                try
                {
                    connection.Insert(tender);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
        }

        public List<Tender> SelectAllTenders()
        {
            using (var connection = _connectionFactory.GetConnection())
            {
                try
                {
                    return connection.Select<Tender>();
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