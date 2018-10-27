using System.Collections.Generic;
using TenderApplicationBackend.Models.Dtos;
using TenderApplicationBackend.Models.Entities;
using TenderApplicationBackend.Models.Repositories;

namespace TenderApplicationBackend.Models.Modules
{
    public class UserModule
    {
        private readonly UserRepository _userRepository;
        private readonly EmployeeRepository _employeeRepository;

        public UserModule(UserRepository userRepository, EmployeeRepository employeeRepository)
        {
            _userRepository = userRepository;
            _employeeRepository = employeeRepository;
        }

        public void AddUser(UserEmployeeRequest userEmployeeAddRequest)
        {
            var user = new User
            {
                Username = userEmployeeAddRequest.Username,
                UserPass = userEmployeeAddRequest.UserPass,
                Role = userEmployeeAddRequest.Role
            };
            _userRepository.SaveUser(user);

            var result = _userRepository.SelectUserByUsername(userEmployeeAddRequest);

            var employee = new Employee
            {
                UserID = result.Id,
                FName = userEmployeeAddRequest.FName,
                LName = userEmployeeAddRequest.LName
            };
            _employeeRepository.SaveEmployee(employee);     
        }

        public List<UserEmployeeRequest> SelectAllUsers()
        {
            var result = _userRepository.SelectAllUsers();
            var listOfUsers = new List<UserEmployeeRequest>();
            var userRequest = new UserEmployeeRequest();

            foreach (var t in result)
            {
                userRequest.UserId = t.Id;
                userRequest.Username = t.Username;
                userRequest.Role = t.Role;
                listOfUsers.Add(userRequest);
            }

            return listOfUsers;
        }

        //public UserEmployeeRequest SelectUserByUsername(UserEmployeeRequest userRequest)
        //{
        //    var result = _userRepository.SelectUserByUsername(userRequest);
        //    var user = new UserEmployeeRequest
        //    {
        //        Username = result.Username,
        //        Role = result.Role,
        //        UserID = result.Id
        //    };

        //    return user;
        //}
    }
}
