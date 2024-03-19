using Examination_System_Web_App.Models;

namespace Examination_System_Web_App.Repositories
{
	public interface IStudentRepository
	{
		public Student GetStudent(int id);
		public List<Question> GetAllQuestions(int Exam_id);
		public void SumbitAnswers(int exam_id, int std_id, Dictionary<int, int> StdAnswers);
		public void ExamCorrection(int ExamID, int StudentID);


	}
}
