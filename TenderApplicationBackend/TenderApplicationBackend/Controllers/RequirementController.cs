using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using TenderApplicationBackend.Models.Dtos;
using TenderApplicationBackend.Models.Modules;

namespace TenderApplicationBackend.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AllowAll")]
    [Authorize(Roles = "MAN, ANAL, OFF")]
    [ApiController]
    public class RequirementController : ControllerBase
    {
        private readonly RequirementModule _requirementModule;

        public RequirementController(RequirementModule requirementModule)
        {
            _requirementModule = requirementModule;
        }

        //GET api/requirement
        [HttpGet]
        public List<RequirementRequest> Get()
        {
            return _requirementModule.SelectAllRequirements();
        }

        [HttpGet("{id}")]
        public List<RequirementRequest> Get(int id)
        {
            return _requirementModule.SelectRequirementsByTenderId(id);
        }

        // POST api/requirement posting new requirements
        [HttpPost]
        public void Post([FromBody] RequirementRequest value)
        {
            _requirementModule.AddRequirement(value);
        }

        // POST api/requirement/5   edit requirement with id = 5
        [HttpPost("{id}")]
        public void Post(int id, [FromBody] RequirementRequest tenderValue)
        {
            _requirementModule.EditRequirement(id, tenderValue);
        }

        // DELETE api/requirement/5 delete requirement with id = 5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _requirementModule.DeleteRequirement(id);
        }
    }
}