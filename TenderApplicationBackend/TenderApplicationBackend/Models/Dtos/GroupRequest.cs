namespace TenderApplicationBackend.Models.Dtos
{
    public class GroupRequest
    {
        public int EmployeeId { get; set; }
        public string Employee { get; set; }
        public int Workhours { get; set; }
        public int GroupId { get; set; }
        public string Name { get; set; }
    }
}
