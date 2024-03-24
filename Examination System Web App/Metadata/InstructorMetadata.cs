using Examination_System_Web_App.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Examination_System_Web_App.Models
{
    public class InstructorMetadata
    {
        [Display(Name = "Instructor ID")]
        public int ins_id { get; set; }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "First name is required")]
        public string ins_fname { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Last name is required")]
        public string ins_lname { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string ins_email { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Password is required")]
        public string ins_password { get; set; }

        [Display(Name = "Age")]
        public int? ins_age { get; set; }

        [Display(Name = "Gender")]
        [StringLength(1,ErrorMessage ="Gender Must be inputed as a Single Character M or F")]
        public string ins_gender { get; set; }


        [Display(Name = "Salary")]
        [Range(1,int.MaxValue,ErrorMessage ="Salary Must be A positive Number")]
        public int ins_salary { get; set; }


    }

    [ModelMetadataType(typeof(InstructorMetadata))]
    public partial class Instructor
    {
    }
}
