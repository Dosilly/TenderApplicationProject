using ServiceStack.DataAnnotations;
using ServiceStack.Model;

namespace TenderApplicationBackend.Models.Entities
{
    public class Employee : IHasId<int>
    {
        public int UserId { get; set; }
        public string LName { get; set; }
        public string FName { get; set; }

        [Alias("EmployeeID")] [AutoIncrement] public int Id { get; set; }
    }
}