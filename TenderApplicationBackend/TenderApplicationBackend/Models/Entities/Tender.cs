using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServiceStack.DataAnnotations;
using ServiceStack.Model;

namespace TenderApplicationBackend.Models.Entities
{
    public class Tender: IHasId<int>
    {
        public string TenderName { get; set; }
        public int EmployeeId { get; set; }
        public string State { get; set; }

        [Alias("TenderID")] [AutoIncrement] public int Id { get; set; }
    }
}
