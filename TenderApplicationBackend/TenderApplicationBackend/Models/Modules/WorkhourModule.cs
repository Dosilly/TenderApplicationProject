using System;
using System.Collections.Generic;
using TenderApplicationBackend.Models.Dtos;
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
            throw new NotImplementedException();
        }

        public void AddWorkhour(WorkhourRequest value)
        {
            throw new NotImplementedException();
        }

        public void EditWorkhour(int id, WorkhourRequest value)
        {
            throw new NotImplementedException();
        }

        public void DeleteWorkhour(int id)
        {
            throw new NotImplementedException();
        }
    }
}
