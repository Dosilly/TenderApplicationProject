using System;
using System.Collections.Generic;
using TenderApplicationBackend.Models.Dtos;
using TenderApplicationBackend.Models.Entities;
using TenderApplicationBackend.Models.Repositories;

namespace TenderApplicationBackend.Models.Modules
{
    public class WorkhourModule
    {
        private readonly WorkhourRepository _workhourRepository;
        private readonly EmployeeRepository _employeeRepository;

        public WorkhourModule(WorkhourRepository workhourRepository, EmployeeRepository EmployeeRepository)
        { 
            _workhourRepository = workhourRepository;
            _employeeRepository = EmployeeRepository;
        }
        public List<WorkhourRequest> SelectAllWorkhours()
        {
            var whRes = _workhourRepository.SelectAllWorkhours();
            var listWh = new List<WorkhourRequest>();

            foreach (var e in whRes)
            {
                var workhourRequest = new WorkhourRequest
                {
                    EmployeeId = e.EmployeeId,
                    ReqId = e.ReqId,
                    WhId = e.Id,
                    Workhours = e.Workhours
                };
                var employee = _employeeRepository.SelectEmployeeById(workhourRequest.EmployeeId);
                workhourRequest.Employee = employee.FName + " " + employee.LName;
                listWh.Add(workhourRequest);
            }

            return listWh;
        }

        public List<WorkhourRequest> SelectWorkhoursByRequirementId(int id)
        {
            var whRes = _workhourRepository.SelectWorkhoursByRequirementId(id);
            var listWh = new List<WorkhourRequest>();

            foreach (var e in whRes)
            {
                var workhourRequest = new WorkhourRequest
                {
                    EmployeeId = e.EmployeeId,
                    ReqId = e.ReqId,
                    WhId = e.Id,
                    Workhours = e.Workhours
                };
                var employee = _employeeRepository.SelectEmployeeById(workhourRequest.EmployeeId);
                workhourRequest.Employee = employee.FName + " " + employee.LName;
                listWh.Add(workhourRequest);
            }

            return listWh;
        }

        public void AddWorkhour(WorkhourRequest value)
        {
            var workhour = new Workhour
            {
                EmployeeId = value.EmployeeId,
                ReqId = value.ReqId,
                Workhours = value.Workhours
            };

            _workhourRepository.AddWorkhour(workhour);

        }

        public void EditWorkhour(int id, WorkhourRequest value)
        {
            var workhour = new Workhour
            {
                Id = id,
                EmployeeId = value.EmployeeId,
                ReqId = value.ReqId,
                Workhours = value.Workhours
            };

            _workhourRepository.EditWorkhour(workhour);
        }

        public void DeleteWorkhour(int id)
        {
            _workhourRepository.DeleteWorkhour(id);
        }
    }
}
