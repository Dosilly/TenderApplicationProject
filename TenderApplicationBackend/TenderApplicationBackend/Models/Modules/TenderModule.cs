using System.Collections.Generic;
using System.Linq;
using TenderApplicationBackend.Models.Dtos;
using TenderApplicationBackend.Models.Entities;
using TenderApplicationBackend.Models.Interfaces;
using TenderApplicationBackend.Models.Repositories;

namespace TenderApplicationBackend.Models.Modules
{
    public class TenderModule
    {
        private readonly ITenderRepository _tenderRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IRequirementRepository _requirementRepository;
        private readonly IWorkhourRepository _workhourRepository;
        private readonly IGroupRepository _groupRepository;

        public TenderModule(ITenderRepository tenderRepository, IEmployeeRepository employeeRepository, IRequirementRepository requirementRepository, IWorkhourRepository workhourRepository, IGroupRepository groupRepository)
        {
            _tenderRepository = tenderRepository;
            _employeeRepository = employeeRepository;
            _requirementRepository = requirementRepository;
            _workhourRepository = workhourRepository;
            _groupRepository = groupRepository;
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
                var employee = _employeeRepository.SelectEmployeeById(tenderRequest.EmployeeId);
                tenderRequest.Employee = employee.FName + " " + employee.LName;

                tenderRequest.TotalWh = EstimateTotalWorkhours(tenderRequest.TenderId);
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

        public int EstimateTotalWorkhours(int tenderId)
        {
            var totalwh = 0;
            var requirements = _requirementRepository.SelectRequirementsByTenderId(tenderId);

            foreach (var r in requirements)
            {
                var total = 0;
                var reqgroups = _groupRepository.SelectGroupsByRequirementId(r.Id);

                if (reqgroups != null && reqgroups.Count > 0)
                {
                    totalwh += reqgroups[0].Workhours;
                    continue;
                }

                var workhours = _workhourRepository.SelectWorkhoursByRequirementId(r.Id);

                foreach (var w in workhours)
                {
                    total += w.Workhours;
                }

                if (total == 0) continue;
                var average = total / workhours.Count;
                totalwh += average;
            }

            return totalwh;
        }
    }


}