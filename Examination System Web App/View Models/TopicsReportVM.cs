using System.ComponentModel.DataAnnotations;

namespace Examination_System_Web_App.View_Models
{
    public class TopicsReportVM
    {
        [Display(Name = "Course Name")]
        public string crs_name { get; set; }
        [Display(Name = "Topic Name")]
        public string top_name { get; set; }
    }
}
