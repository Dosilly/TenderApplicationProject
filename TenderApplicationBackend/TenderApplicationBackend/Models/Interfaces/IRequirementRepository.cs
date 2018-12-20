using System.Collections.Generic;
using TenderApplicationBackend.Models.Entities;

namespace TenderApplicationBackend.Models.Repositories
{
    public interface IRequirementRepository
    {
        void AddRequirement(Requirement requirement);
        void DeleteRequirement(int id);
        void EditRequirement(Requirement requirement);
        List<Requirement> SelectAllRequirements();
        List<Requirement> SelectRequirementsByTenderId(int id);
    }
}