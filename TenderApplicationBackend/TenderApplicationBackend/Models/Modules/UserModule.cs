﻿using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using ServiceStack;
using TenderApplicationBackend.Models.Dtos;
using TenderApplicationBackend.Models.Entities;
using TenderApplicationBackend.Models.Repositories;

namespace TenderApplicationBackend.Models.Modules
{
    public class UserModule
    {
        private readonly EmployeeRepository _employeeRepository;
        private readonly UserRepository _userRepository;

        public UserModule(UserRepository userRepository, EmployeeRepository employeeRepository)
        {
            _userRepository = userRepository;
            _employeeRepository = employeeRepository;
        }

        public void AddUser(UserEmployeeRequest userEmployeeAddRequest)
        {
            var hashnSalt = HashPassword(userEmployeeAddRequest.UserPass);

            var user = new User
            {
                Username = userEmployeeAddRequest.Username,
                UserPass = hashnSalt.Item1,
                Salt = hashnSalt.Item2,
                Role = userEmployeeAddRequest.Role
            };
            _userRepository.SaveUser(user);

            var result = _userRepository.SelectUserByUsername(userEmployeeAddRequest.Username);

            var employee = new Employee
            {
                UserId = result.Id,
                FName = userEmployeeAddRequest.FName,
                LName = userEmployeeAddRequest.LName
            };
            _employeeRepository.SaveEmployee(employee);
        }

        public void DeleteUser(int userId)
        {
            _employeeRepository.DeleteEmployee(userId);
            _userRepository.DeleteUser(userId);
        }

        public void EditUser(int idToChange, UserEmployeeRequest userEmployeeAddRequest)
        {
            var user = new User
            {
                Username = userEmployeeAddRequest.Username,
                Role = userEmployeeAddRequest.Role,
                Id = idToChange
            };

            if (!userEmployeeAddRequest.UserPass.IsNullOrEmpty())
            {
                var hashnSalt = HashPassword(userEmployeeAddRequest.UserPass);
                user.Salt = hashnSalt.Item2;
                user.UserPass = hashnSalt.Item1;
            }

            _userRepository.EditUser(user);

            var employee = new Employee
            {
                FName = userEmployeeAddRequest.FName,
                LName = userEmployeeAddRequest.LName,
                UserId = userEmployeeAddRequest.UserId
            };

            _employeeRepository.EditEmployee(employee);
        }

        public List<UserEmployeeRequest> SelectAllUsers()
        {
            var usrResult = _userRepository.SelectAllUsers();
            var empResult = _employeeRepository.SelectAllEmployees();
            var listOfUsers = new List<UserEmployeeRequest>();

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

        private static Tuple<string, string> HashPassword(string password)
        {
            // generate a 128-bit salt using a secure PRNG
            var salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            var hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password,
                salt,
                KeyDerivationPrf.HMACSHA1,
                10000,
                256 / 8));


            return Tuple.Create(hashed, Convert.ToBase64String(salt));
        }
    }
}