using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using TenderApplicationBackend.Models.Dtos;
using TenderApplicationBackend.Models.Modules;

namespace TenderApplicationBackend.Controllers
{
    [Route("api/[controller]")]
    //[EnableCors("AllowAll")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserModule _userModule;

        public UserController(UserModule userModule)
        {
            _userModule = userModule;
        }

        // GET api/user get users
        [HttpGet]
        [Authorize(Roles = "ADM")]
        public List<UserEmployeeRequest> Get()
        {
            return _userModule.SelectAllUsers();
        }

        // POST api/user post new user
        [HttpPost]
        [Authorize(Roles = "ADM")]
        public void Post([FromBody] UserEmployeeRequest userValue)
        {
            _userModule.AddUser(userValue);
        }

        // PUT api/user/5   edit user with id = 5
        [HttpPost("{id}")]
        [Authorize(Roles = "ADM")]
        public void Post(int id, [FromBody] UserEmployeeRequest userValue)
        {
            _userModule.EditUser(id, userValue);
        }

        // DELETE api/user/5 delete user with id = 5
        [HttpDelete("{id}")]
        [Authorize(Roles = "ADM")]
        public void Delete(int id)
        {
            _userModule.DeleteUser(id);
        }
    }
}