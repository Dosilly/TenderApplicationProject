using TenderApplicationBackend.Models.Dtos;
using TenderApplicationBackend.Models.Entities;
using TenderApplicationBackend.Models.Repositories;

namespace TenderApplicationBackend.Models.Modules
{
    public class EmployeeModule
    {
        private readonly EmployeeRepository _employeeRepository;

        public EmployeeModule(EmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public EmployeeRequest AddEmployee(EmployeeRequest employeeRequest)
        {
   
            var employee = new Employee
            {
                FName = employeeRequest.FName,
                LName = employeeRequest.LName
            };

            _employeeRepository.SaveEmployee(employee);

            return employeeRequest;
        }
    }
}
