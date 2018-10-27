using TenderApplicationBackend.Models.Dtos;
using TenderApplicationBackend.Models.Entities;
using TenderApplicationBackend.Models.Repositories;

namespace TenderApplicationBackend.Models.Modules
{
    public class EmployeeModule
    {
        private readonly EmployeeRepository _employeeRepository;
        private readonly UserModule _userModule;

        public EmployeeModule(EmployeeRepository employeeRepository, UserModule userModule)
        {
            _userModule = userModule;
            _employeeRepository = employeeRepository;
        }

    }
}
