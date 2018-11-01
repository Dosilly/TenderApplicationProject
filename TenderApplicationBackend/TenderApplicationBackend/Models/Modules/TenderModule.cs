using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TenderApplicationBackend.Models.Dtos;
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
            throw new NotImplementedException();
        }

        public void AddTender(TenderRequest tender)
        {
            throw new NotImplementedException();
        }
    }
}
