using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TenderApplicationBackend.Models.Dtos
{
    public class UserEmployeeRequest
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string UserPass { get; set; }
        public string Role { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string Salt { get; set; }
    }
}
