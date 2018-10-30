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
    public class UserController : ControllerBase
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

        // POST users/values posting new users
        [HttpPost]
        public void Post([FromBody] UserEmployeeRequest userValue)
        {
            _userModule.AddUser(userValue);
        }

        // PUT api/values/5   editing users
        [HttpPost("{id}")]
        public void Post(int id, [FromBody] UserEmployeeRequest userValue)
        {
            _userModule.EditUser(id, userValue);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _userModule.DeleteUser(id);
        }
    }
}