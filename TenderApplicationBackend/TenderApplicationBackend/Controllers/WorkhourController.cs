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
    public class WorkhourController: ControllerBase
    {
        private readonly WorkhourModule _workhourModule;

        public WorkhourController(WorkhourModule workhourModule)
        {
            _workhourModule = workhourModule;
        }

        //GET api/workhour
        [HttpGet]
        public List<WorkhourRequest> Get()
        {
            return _workhourModule.SelectAllWorkhours();
        }

        //GET api/workhour/5 workhours for req with id = 5
        [HttpGet("{id}")]
        public List<WorkhourRequest> Get(int id)
        {
            return _workhourModule.SelectWorkhoursByRequirementId(id);
        }

        // POST api/workhour posting new workhours
        [HttpPost]
        public void Post([FromBody] WorkhourRequest value)
        {
            _workhourModule.AddWorkhour(value);
        }

        // POST api/workhour/5   edit workhour with id = 5
        [HttpPost("{id}")]
        public void Post(int id, [FromBody] WorkhourRequest value)
        {
            _workhourModule.EditWorkhour(id, value);
        }

        // DELETE api/workhour/5 delete workhour with id = 5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _workhourModule.DeleteWorkhour(id);
        }

    }
}
