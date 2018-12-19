using System.Collections.Generic;
using TenderApplicationBackend.Models.Entities;

namespace TenderApplicationBackend.Models.Repositories
{
    public interface IWorkhourRepository
    {
        void AddWorkhour(Workhour workhour);
        void DeleteWorkhour(int id);
        void EditWorkhour(Workhour workhour);
        List<Workhour> SelectAllWorkhours();
        List<Workhour> SelectWorkhoursByRequirementId(int id);
    }
}