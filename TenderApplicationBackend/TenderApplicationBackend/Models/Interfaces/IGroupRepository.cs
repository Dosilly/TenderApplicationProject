using System.Collections.Generic;
using TenderApplicationBackend.Models.Entities;

namespace TenderApplicationBackend.Models.Repositories
{
    public interface IGroupRepository
    {
        void AddGroup(Group group);
        void DeleteGroup(int id);
        void EditGroup(Group group);
        List<Group> SelectAllGroups();
        List<Group> SelectGroupsByRequirementId(int id);
    }
}