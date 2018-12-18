﻿using System.Collections.Generic;
using TenderApplicationBackend.Models.Dtos;
using TenderApplicationBackend.Models.Entities;
using TenderApplicationBackend.Models.Repositories;

namespace TenderApplicationBackend.Models.Modules
{
    public class TenderModule
    {
        private readonly TenderRepository _tenderRepository;
        private readonly EmployeeRepository _employeeRepository;
        private readonly RequirementRepository _requirementRepository;
        private readonly WorkhourRepository _workhourRepository;

        public TenderModule(TenderRepository tenderRepository, EmployeeRepository employeeRepository, RequirementRepository requirementRepository, WorkhourRepository workhourRepository)
        {
            _tenderRepository = tenderRepository;
            _employeeRepository = employeeRepository;
            _requirementRepository = requirementRepository;
            _workhourRepository = workhourRepository;
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
                var workhours = _workhourRepository.SelectWorkhoursByRequirementId(r.Id);
                var total = 0;
                var average = 0;

                foreach (var w in workhours)
                {
                    total += w.Workhours;
                }

                if (total != 0)
                {
                    average = total / workhours.Count;
                    totalwh += average;
                }


            }

            return totalwh;
        }
    }
}