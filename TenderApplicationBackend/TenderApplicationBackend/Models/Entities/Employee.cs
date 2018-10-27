using ServiceStack.DataAnnotations;
using ServiceStack.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TenderApplicationBackend.Models.Entities
{
    public class Employee : IHasId<int>
    {
        [Alias("EmployeeID")]
        [AutoIncrement]
        public int Id { get; set; }
        public  int UserID { get; set; }
        public string LName { get; set; }
        public string FName { get; set; }
    }
}
