using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using TenderApplicationBackend.Models.Dtos;
using TenderApplicationBackend.Models.Modules;

namespace TenderApplicationBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController: ControllerBase
    {
        private readonly UserModule _userModule;

        public UserController(UserModule userModule)
        {
            _userModule = userModule;
        }

        // GET api/values
        [HttpGet]
        public List<UserEmployeeRequest> Get()
        {
            return _userModule.SelectAllUsers();
        }

        // GET api/users/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "Return user by id";
        }

        // POST users/values
        [HttpPost]
        public void Post([FromBody] UserEmployeeRequest userValue)
        {
            _userModule.AddUser(userValue);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
