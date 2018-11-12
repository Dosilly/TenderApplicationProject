using ServiceStack.DataAnnotations;
using ServiceStack.Model;


namespace TenderApplicationBackend.Models.Entities
{
    // ReSharper disable once InconsistentNaming
    public class Requirement_group : IHasId<int>
    {
        public int ReqId { get; set; }
        public int GroupId { get; set; }

        [Alias("ReqGroupId")] [AutoIncrement] public int Id { get; set; }
    }
}
