using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TenderApplicationBackend.Models.Dtos
{
    public class RequirementRequest
    {
        public int ReqId { get; set; }
        public int TenderId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Explanation { get; set; }
    }
}
