using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Localization;
using TenderApplicationBackend.Models.Dtos;
using TenderApplicationBackend.Models.Entities;
using TenderApplicationBackend.Models.Repositories;

namespace TenderApplicationBackend.Models.Modules
{
    public class GroupModule
    {
        private readonly GroupRepository _groupRepository;
        private readonly EmployeeRepository _employeeRepository;

        public GroupModule(GroupRepository groupRepository, EmployeeRepository employeeRepository)
        {
            _groupRepository = groupRepository;
            _employeeRepository = employeeRepository;
        }

        public List<GroupRequest> SelectAllGroups()
        {
            var groupResult = _groupRepository.SelectAllGroups();
            var listOfGroups = new List<GroupRequest>();

            foreach (var e in groupResult)
            {
                var groupRequest = new GroupRequest
                {
                    GroupId = e.Id,  
                    EmployeeId = e.EmployeeId,
                    Name = e.Name,
                    Workhours = e.Workhours
                };
                var employee = _employeeRepository.SelectEmployeeById(groupRequest.EmployeeId);
                groupRequest.Employee = employee.FName + " " + employee.LName;
                listOfGroups.Add(groupRequest);
            }

            return listOfGroups;
        }

        public List<GroupRequest> SelectGroupsByRequirementId(int id)
        {
            
            var groupResult = _groupRepository.SelectGroupsByRequirementId(id);
            var listOfGroups = new List<GroupRequest>();

            foreach (var e in groupResult)
            {
                var groupRequest = new GroupRequest
                {
                    GroupId = e.Id,
                    EmployeeId = e.EmployeeId,
                    Name = e.Name,
                    Workhours = e.Workhours
                };
                var employee = _employeeRepository.SelectEmployeeById(groupRequest.EmployeeId);
                groupRequest.Employee = employee.FName + " " + employee.LName;
                listOfGroups.Add(groupRequest);
            }

            return listOfGroups;
        }

        public void AddGroup(GroupRequest value)
        {
            var group = new Group
            {
                EmployeeId = value.EmployeeId,
                Name = value.Name,
                Workhours = value.Workhours
            };

            _groupRepository.AddGroup(group);
        }

        public void EditGroup(int id, GroupRequest value)
        {
            var group = new Group
            {
                Id = id,
                EmployeeId = value.EmployeeId,
                Name = value.Name,
                Workhours = value.Workhours
            };

            _groupRepository.EditGroup(group);
        }

        public void DeleteGroup(int id)
        {
            _groupRepository.DeleteGroup(id);
        }
    }
}
