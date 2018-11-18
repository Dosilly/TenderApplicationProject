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
    public class LoginController : ControllerBase
    {
        private readonly AuthenticationModule _authenticationModule;

        public LoginController(AuthenticationModule authenticationModule)
        {
            _authenticationModule = authenticationModule;
        }

        [HttpPost]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            return Ok(_authenticationModule.Login(request));
        }
    }
}
