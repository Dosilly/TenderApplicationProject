using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TenderApplicationBackend.Models.Dtos
{
    public class UserRequest
    {
        public string Username { get; set; }
        public string UserPass { get; set; }
        public string Role { get; set; }

    }
}
