using Examination_System_Web_App.Models;

namespace Examination_System_Web_App.View_Models
{
	public class QuestionWithItsChoices
	{
		public int q_id { get; set; }

		public string q_text { get; set; }

		public string q_type { get; set; }

		public int? q_modalanswer { get; set; }

		public int? q_score { get; set; }

		public int? crs_id { get; set; }
		public int ch_no { get; set; }
		public string ch_text { get; set; }
	}
}
