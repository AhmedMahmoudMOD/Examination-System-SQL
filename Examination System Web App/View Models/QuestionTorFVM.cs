using System.ComponentModel.DataAnnotations;

namespace Examination_System_Web_App.View_Models
{
    public class QuestionTorFVM
    {
        public int CrsId { get; set; }
        [MinLength(5)]
        [Display(Name = "Question Body")]
        public string Q_Text { get; set; }

        [Display(Name = "Model Answer")]
        public int ModelAnswer { get; set; }
        [Display(Name = "Question Score")]
        [Range(1, 5)]
        public int Q_Score { get; set; }

    }
}
