using System;
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
            var usrResult = _userRepository.SelectAllUsers();
            var empResult = _employeeRepository.SelectAllEmployees();
            var listOfUsers = new List<UserEmployeeRequest>();

            Console.Write(usrResult);
            Console.Write(empResult);

            for (var i = 0; i < usrResult.Count; i++)
            {
                var userEmployeeRequest = new UserEmployeeRequest();
                var u = usrResult[i];
                var e = empResult[i];

                userEmployeeRequest.UserId = u.Id;
                userEmployeeRequest.Username = u.Username;
                userEmployeeRequest.Role = u.Role;
                userEmployeeRequest.FName = e.FName;
                userEmployeeRequest.LName = e.LName;

                listOfUsers.Add(userEmployeeRequest);
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
