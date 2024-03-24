using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Examination_System_Web_App.Models
{
    public class StudentMetadata
    {
        [Display(Name = "Student ID")]
        public int std_id { get; set; }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "First name is required")]
        public string std_fname { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Last name is required")]
        public string std_lname { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string std_email { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Password is required")]
        public string std_password { get; set; }

        [Display(Name = "Age")]
        [Range(21, 29, ErrorMessage = "Age must be between 21 and 29")]
        public int? std_age { get; set; }

        [Display(Name = "Gender")]
        [StringLength(1,ErrorMessage = "Gender Must be inputed as a Single Character M or F")]
        public string std_gender { get; set; }

        [Display(Name = "Department Number")]
        public int? dept_no { get; set; }

        
    }

    [ModelMetadataType(typeof(StudentMetadata))]
    public partial class Student
    {
    }
}
