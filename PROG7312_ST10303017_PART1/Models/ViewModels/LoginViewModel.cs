using System.ComponentModel.DataAnnotations;

namespace PROG7312_ST10303017_PART1.Models.ViewModels
{
    // ViewModel for user login
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Username is required")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
