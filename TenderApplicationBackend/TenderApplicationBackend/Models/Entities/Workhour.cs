using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServiceStack.DataAnnotations;
using ServiceStack.Model;

namespace TenderApplicationBackend.Models.Entities
{
    public class Workhour: IHasId<int>
    {
        public int ReqId { get; set; }
        public int EmployeeId { get; set; }
        public int Workhours { get; set; }
        [Alias("WhID")] [AutoIncrement] public int Id { get; set; }
    }
}
