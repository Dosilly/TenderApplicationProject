using System.Collections.Generic;
using TenderApplicationBackend.Models.Dtos;
using TenderApplicationBackend.Models.Entities;
using TenderApplicationBackend.Models.Repositories;

namespace TenderApplicationBackend.Models.Modules
{
    public class TenderModule
    {
        private readonly TenderRepository _tenderRepository;

        public TenderModule(TenderRepository tenderRepositoryRepository)
        {
            _tenderRepository = tenderRepositoryRepository;
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
    }
}