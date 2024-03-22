using System.ComponentModel.DataAnnotations;

namespace Examination_System_Web_App.View_Models
{
    public class LoginViewModel
    {
        [Required]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
