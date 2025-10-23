namespace CMCSystem.Models
{
    public class Claim
    {
        public int Id { get; set; }
        public string PassengerName { get; set; }
        public string ClaimType { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public string DocumentPath { get; set; }
    }
}
