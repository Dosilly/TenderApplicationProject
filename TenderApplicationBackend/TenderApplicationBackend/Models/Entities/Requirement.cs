using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServiceStack.DataAnnotations;
using ServiceStack.Model;

namespace TenderApplicationBackend.Models.Entities
{
    public class Requirement:IHasId<int>
    {
        public int TenderId { get; set; }
        public string Name  { get; set; }
        public string Description { get; set; }
        public string Explanation { get; set; }
        [Alias("ReqID")] [AutoIncrement] public int Id { get; set; }
    }
}
