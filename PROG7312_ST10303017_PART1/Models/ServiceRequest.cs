namespace PROG7312_ST10303017_PART1.Models
{
    // Domain model representing a service request
    public class ServiceRequest
    {
        public string TrackingId { get; set; }
        public string Location { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public string MediaFileName { get; set; } 
        public DateTime SubmittedDate { get; set; }
        public string Status { get; set; }
        public string SubmittedByUsername { get; set; }
    }
}
