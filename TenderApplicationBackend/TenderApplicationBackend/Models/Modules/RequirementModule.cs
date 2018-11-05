using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TenderApplicationBackend.Models.Dtos;
using TenderApplicationBackend.Models.Entities;
using TenderApplicationBackend.Models.Repositories;

namespace TenderApplicationBackend.Models.Modules
{
    public class RequirementModule
    {
        private readonly RequirementRepository _requirementRepository;
        public RequirementModule(RequirementRepository requirementRepository)
        {
            _requirementRepository = requirementRepository;
        }
        public List<RequirementRequest> SelectAllRequirements()
        {
            var reqRes = _requirementRepository.SelectAllRequirements();
            var listReq = new List<RequirementRequest>();

            foreach (var e in reqRes)
            {
                var requirementRequest = new RequirementRequest()
                {
                    ReqId = e.Id,
                    TenderId = e.TenderId,
                    Description = e.Description,
                    Explanation = e.Explanation,
                    Name = e.Name
                };

                listReq.Add(requirementRequest);
            }

            return listReq;
        }

        public void AddRequirement(RequirementRequest requirementRequest)
        {
            var requirement = new Requirement()
            {
                TenderId = requirementRequest.TenderId,
                Description = requirementRequest.Description,
                Explanation = requirementRequest.Explanation,
                Name = requirementRequest.Name
            };

            _requirementRepository.AddRequirement(requirement);
        }

        public void DeleteRequirement(int id)
        {
            _requirementRepository.DeleteRequirement(id);
        }

        public void EditRequirement(int id, RequirementRequest tenderValue)
        {
            var requirement = new Requirement()
            {
                Id = id,
                Description = tenderValue.Description,
                Explanation = tenderValue.Explanation,
                Name = tenderValue.Name
            };

            _requirementRepository.EditRequirement(requirement);
        }
    }
}
