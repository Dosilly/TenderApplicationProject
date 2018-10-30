using ServiceStack.DataAnnotations;
using ServiceStack.Model;

namespace TenderApplicationBackend.Models.Entities
{
    public class User : IHasId<int>
    {
        public string Username { get; set; }
        public string UserPass { get; set; }
        public string Role { get; set; }
        public string Salt { get; set; }

        [Alias("UserID")] [AutoIncrement] public int Id { get; set; }
    }
}