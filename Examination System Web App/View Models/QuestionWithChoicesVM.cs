using Examination_System_Web_App.Models;
using System.ComponentModel.DataAnnotations;

namespace Examination_System_Web_App.View_Models
{
    public class QuestionWithChoicesVM
    {
        public int CrsId { get; set; }
        [MinLength(5)]
        [Display(Name = "Question Body")]
        public string Q_Text { get; set; }
        
        [Display(Name = "Choice 1")]
        public string Choice_1 { get; set; }

        [Display(Name = "Choice 2")]
        public string Choice_2 { get; set; }

        [Display(Name = "Choice 3")]
        public string Choice_3 { get; set; }

        [Display(Name = "Choice 4")]
        public string Choice_4 { get; set; }
        [Display(Name = "Model Answer")]
       
        public int ModelAnswer { get; set; }
        [Display(Name = "Question Score")]
        [Range(1, 5)]
        public int Q_Score { get; set; }

    }
}
