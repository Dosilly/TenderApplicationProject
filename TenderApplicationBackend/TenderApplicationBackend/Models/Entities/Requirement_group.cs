 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
 using ServiceStack.DataAnnotations;
 using ServiceStack.Model;

namespace TenderApplicationBackend.Models.Entities
{
    // ReSharper disable once InconsistentNaming
    public class Requirement_group
    {
        public int ReqGroupId { get; set; }
        public int ReqId { get; set; }
        public int GroupId { get; set; }
    }
}
