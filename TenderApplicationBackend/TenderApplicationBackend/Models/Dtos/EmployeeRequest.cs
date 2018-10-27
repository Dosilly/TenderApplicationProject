using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TenderApplicationBackend.Models.Dtos
{
    public class EmployeeRequest
    {
        public int UserID { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
    }
}
