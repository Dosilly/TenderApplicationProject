using System.Collections.Generic;
using TenderApplicationBackend.Models.Dtos;
using TenderApplicationBackend.Models.Entities;
using TenderApplicationBackend.Models.Repositories;

namespace TenderApplicationBackend.Models.Modules
{
    public class TenderModule
    {
        private readonly TenderRepository _tenderRepository;
        private readonly EmployeeRepository _employeeRepository;  

        public TenderModule(TenderRepository tenderRepository, EmployeeRepository EmployeeRepository)
        {
            _tenderRepository = tenderRepository;
            _employeeRepository = EmployeeRepository;
        }

        public List<TenderRequest> SelectAllTenders()
        {
            var tenderRes = _tenderRepository.SelectAllTenders();
            var listOfTenders = new List<TenderRequest>();
            

            foreach (var e in tenderRes)
            {
                var tenderRequest = new TenderRequest
                {
                    EmployeeId = e.EmployeeId,
                    State = e.State,
                    TenderId = e.Id,
                    TenderName = e.TenderName
                };
                var employee = new Employee();
                employee = _employeeRepository.SelectEmployeeById(tenderRequest.EmployeeId);
                tenderRequest.Employee = employee.FName + " " + employee.LName;
                listOfTenders.Add(tenderRequest);

            }

            return listOfTenders;
        }

        public void AddTender(TenderRequest tenderRequest)
        {
            var tender = new Tender
            {
                TenderName = tenderRequest.TenderName,
                EmployeeId = tenderRequest.EmployeeId,
                State = tenderRequest.State
            };

            _tenderRepository.AddTender(tender);
        }

        public void DeleteTender(int id)
        {
            _tenderRepository.DeleteTender(id);
        }

        public void EditTender(int id, TenderRequest tenderValue)
        {
            var tender = new Tender()
            {
                Id = id,
                TenderName = tenderValue.TenderName,
                State = tenderValue.State,
                EmployeeId = tenderValue.EmployeeId
            };

            _tenderRepository.EditTender(tender);
        }
    }
}