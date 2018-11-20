using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TenderApplicationBackend.Models.Dtos;
using TenderApplicationBackend.Models.Entities;
using TenderApplicationBackend.Models.Repositories;

namespace TenderApplicationBackend.Models.Modules
{
    public class ReqgroupModule
    {
        private readonly ReqgroupRepository _reqgroupRepository;

        public ReqgroupModule(ReqgroupRepository reqgroupRepository)
        {
            _reqgroupRepository = reqgroupRepository;
        }

        public void AddToGroup(int id, List<ReqgroupRequest> value)
        {
            var reqGroupList = new List<Requirement_group>();
            foreach (var e in value)
            {
                var reqgroup = new Requirement_group
                {
                    GroupId = id,
                    ReqId = e.ReqId
                };
                reqGroupList.Add(reqgroup);
            }

            _reqgroupRepository.AddToGroup(reqGroupList);
        }

        public void DeleteFromGroup(int reqId, int groupId)
        {
            _reqgroupRepository.DeleteFromGroup(reqId, groupId);
        }
    }
}
