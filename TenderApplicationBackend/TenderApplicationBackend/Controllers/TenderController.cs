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
   // [Authorize(Roles = "MAN, OFF")]
    [ApiController]
    public class TenderController : ControllerBase
    {
        private readonly TenderModule _tenderModule;

        public TenderController(TenderModule tenderModule)
        {
            _tenderModule = tenderModule;
        }

        // GET api/tender
        [HttpGet]
        public List<TenderRequest> Get()
        {
            return _tenderModule.SelectAllTenders();
        }

        // POST tender posting new tenders
        [HttpPost]
        public void Post([FromBody] TenderRequest tenderValue)
        {
            _tenderModule.AddTender(tenderValue);
        }

        // PUT api/user/5   edit user with id = 5
        [HttpPost("{id}")]
        public void Post(int id, [FromBody] TenderRequest tenderValue)
        {
            _tenderModule.EditTender(id, tenderValue);
        }

        // DELETE api/tender/5 delete tender with id = 5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _tenderModule.DeleteTender(id);
        }
    }
}