using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServiceStack.DataAnnotations;
using ServiceStack.Model;

namespace TenderApplicationBackend.Models.Entities
{
    public class User: IHasId<int>
    {
        [Alias("UserID")]
        [AutoIncrement]
        public int Id { get; set; }
        public string Username { get; set; }
        public string UserPass { get; set; }
        public string Role { get; set; }
        public string Salt { get; set; }
    
    }
}
