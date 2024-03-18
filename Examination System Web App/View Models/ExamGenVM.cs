using Examination_System_Web_App.Validations;
using System.ComponentModel.DataAnnotations;

namespace Examination_System_Web_App.View_Models
{
    public class ExamGenVM
    {

        public int crsId { get; set; }

        public int deptNo { get; set; }
        [Display(Name="Name")]
        [MinLength(5)]
        public string exam_name { get; set; }
        [Display(Name = "Number Of MCQ")]
        public int mcqNo {  get; set; }
        [Display(Name = "Number Of T/F")]
        public int tfNo { get; set; }
        [Display(Name = "Duration")]
        [Range(10, 180, ErrorMessage = "Duration must between 10 and 180 minutes")]
        public int exam_duration { get; set; }
        [Display(Name = "Date")]
        [FutureDate(ErrorMessage = "Date must be in the future.")]
        public DateTime exam_date { get; set; }

        [ValidateTotalQuestions(ErrorMessage = "The sum of MCQ and T/F must be 10.")]
        public int TotalQuestions => mcqNo + tfNo;


    }
}
