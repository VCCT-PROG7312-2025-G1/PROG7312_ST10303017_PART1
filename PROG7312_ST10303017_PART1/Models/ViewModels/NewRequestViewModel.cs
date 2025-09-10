using System.ComponentModel.DataAnnotations;

namespace PROG7312_ST10303017_PART1.Models.ViewModels
{
    // ViewModel for creating a new service request
    public class NewRequestViewModel
    {
        [Required(ErrorMessage = "Location is required.")]
        public string Location { get; set; }

        [Required(ErrorMessage = "Please select a category.")]
        public string Category { get; set; }

        [Required(ErrorMessage = "A detailed description is required.")]
        [Display(Name = "Detailed Description")]
        public string Description { get; set; }

        [Display(Name = "Attach Media (Image/Document)")]
        public IFormFile MediaAttachment { get; set; }
    }
}
