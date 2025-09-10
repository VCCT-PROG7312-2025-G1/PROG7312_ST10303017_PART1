namespace PROG7312_ST10303017_PART1.Models
{
    // ViewModel for error handling
    public class ErrorViewModel
    {
        public string? RequestId { get; set; }

        // Indicates whether to show the RequestId
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
