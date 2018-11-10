using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TenderApplicationBackend.Models.Dtos
{
    public class WorkhourRequest
    {
        public int ReqId { get; set; }
        public int EmployeeId { get; set; }
        public string Employee { get; set; }
        public int Workhours { get; set; }
        public int WhId { get; set; }
    }
}
