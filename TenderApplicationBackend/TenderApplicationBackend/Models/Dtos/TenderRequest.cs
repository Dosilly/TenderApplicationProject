namespace TenderApplicationBackend.Models.Dtos
{
    public class TenderRequest
    {
        public int TenderId { get; set; }
        public string TenderName { get; set; }
        public int EmployeeId { get; set; }
        public int TotalWh { get; set; }
        public string Employee { get; set; }
        public string State { get; set; }
    }
}