using System;
using Microsoft.Extensions.Configuration;
using TenderApplicationBackend.Models;
using TenderApplicationBackend.Models.Modules;
using TenderApplicationBackend.Models.Repositories;
using Xunit;

namespace XUnitTestProject1
{
    public class TenderModule_IsWorkhoursEqual
    {
        private readonly TenderModule _tenderModule;
        private readonly TenderRepository _tenderRepository;
        private readonly EmployeeRepository _employeeRepository;
        private readonly RequirementRepository _requirementRepository;
        private readonly WorkhourRepository _workhourRepository;
        private ConnectionFactory _connectionFactory;
        private readonly IConfiguration _configuration;

        public TenderModule_IsWorkhoursEqual(IConfiguration configuration)
        {
            _configuration = configuration;  
            _connectionFactory = new ConnectionFactory(_configuration);
            _tenderRepository = new TenderRepository(_connectionFactory);
            _employeeRepository = new EmployeeRepository(_connectionFactory);
            _requirementRepository = new RequirementRepository(_connectionFactory);
            _workhourRepository = new WorkhourRepository(_connectionFactory);
            _tenderModule = new TenderModule(_tenderRepository, _employeeRepository, _requirementRepository, _workhourRepository);
        }

        [Fact]
        public void PassingTest()
        {
            Assert.Equal(30, _tenderModule.EstimateTotalWorkhours(2));
        }



        private static int Add(int x, int y)
        {
            return x + y;
        }
    }
}
