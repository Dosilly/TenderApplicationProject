using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServiceStack.DataAnnotations;
using ServiceStack.Model;

namespace TenderApplicationBackend.Models.Entities
{
    public class Group: IHasId<int>
    {
        public int EmployeeId { get; set; }
        public int Workhours { get; set; }
        [Alias("GroupID")] [AutoIncrement] public int Id { get; set; }
    }
}
