using System.Collections.Generic;
using TenderApplicationBackend.Models.Entities;

namespace TenderApplicationBackend.Models.Repositories
{
    public interface IEmployeeRepository
    {
        void DeleteEmployee(int userId);
        void EditEmployee(Employee employee);
        void SaveEmployee(Employee employee);
        List<Employee> SelectAllEmployees();
        Employee SelectEmployeeById(int id);
        Employee SelectEmployeeByUserId(int id);
    }
}