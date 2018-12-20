using System.Collections.Generic;
using TenderApplicationBackend.Models.Entities;

namespace TenderApplicationBackend.Models.Interfaces
{
    public interface IReqgroupRepository
    {
        void AddToGroup(List<Requirement_group> reqGroupList);
        void DeleteFromGroup(int reqId, int groupId);
        bool IsRequirementInGroup(int reqId);
        int GetGroupId(int reqId);
    }
}