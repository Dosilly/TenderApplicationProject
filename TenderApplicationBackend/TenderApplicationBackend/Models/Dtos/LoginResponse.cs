using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace TenderApplicationBackend.Models.Dtos
{
    public class LoginResponse
    {
        public string Token { get; set; }
        public string Username { get; set; }
        public DateTime ExpirationDate { get; set; }
        public object Role { get; set; }
        public int EmployeeId { get; set; }
    }
}
