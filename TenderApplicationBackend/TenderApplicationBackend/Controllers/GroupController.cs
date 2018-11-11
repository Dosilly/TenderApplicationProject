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
    public class GroupController : ControllerBase
    {
        private readonly GroupModule _groupModule;

        public GroupController(GroupModule groupModule)
        {
            _groupModule = groupModule;
        }

        //GET api/group
        [HttpGet]
        public List<GroupRequest> Get()
        {
            return _groupModule.SelectAllGroups();
        }

        //GET api/group/5 groups for req with id = 5
        [HttpGet("{id}")]
        public List<GroupRequest> Get(int id)
        {
            return _groupModule.SelectGroupsByRequirementId(id);
        }

        // POST api/group post new group
        [HttpPost]
        public void Post([FromBody] GroupRequest value)
        {
            _groupModule.AddGroup(value);
        }

        // POST api/group/5   edit group with id = 5
        [HttpPost("{id}")]
        public void Post(int id, [FromBody] GroupRequest value)
        {
            _groupModule.EditGroup(id, value);
        }

        // DELETE api/group/5 delete group with id = 5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _groupModule.DeleteGroup(id);
        }

    }
}
