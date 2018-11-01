using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TenderApplicationBackend.Models.Dtos
{
    public class TenderRequest
    {
        public int TenderId { get; set; }
        public string TenderName { get; set; }
        public int EmployeeId { get; set; }
        public string State { get; set; }
    }
}
