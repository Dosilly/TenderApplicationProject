using System.Collections.Generic;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using TenderApplicationBackend.Models.Dtos;
using TenderApplicationBackend.Models.Modules;

namespace TenderApplicationBackend.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AllowAll")]
    [ApiController]
    public class ReqgroupController: ControllerBase
    {
        private readonly ReqgroupModule _reqgroupModule;

        public ReqgroupController(ReqgroupModule reqgroupModule)
        {
            _reqgroupModule = reqgroupModule;
        }

        // POST api/reqgroup/5 assign list of requirements to group with id = 5
        [HttpPost("{id}")]
        public void Post(int id, [FromBody] List<ReqgroupRequest> value)
        {
            _reqgroupModule.AddToGroup(id, value);
        }

        // DELETE api/workhour/5/5 delete req with id = 5 from group with id = 5
        [HttpDelete("{reqId}/{groupId}")]
        public void Delete(int reqId, int groupId)
        {
            _reqgroupModule.DeleteFromGroup(reqId, groupId);
        }

    }
}
