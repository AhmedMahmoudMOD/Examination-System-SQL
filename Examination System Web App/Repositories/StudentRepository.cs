using Examination_System_Web_App.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Examination_System_Web_App.Repositories
{
	public class StudentRepository : IStudentRepository
	{
		private readonly ExamSysContext db;
		public StudentRepository(ExamSysContext _db)
		{
			db = _db;
		}

		public Student GetStudent(int id)
		{
			var model = db.Students.Include(x => x.Std_courses).ThenInclude(r => r.crs).FirstOrDefault(x => x.std_id == id);
			return model;
		}
		public List<Question> GetAllQuestions(int Exam_id)
		{
			// Create parameters for the stored procedure
			var param1 = new SqlParameter("@Exam_id", Exam_id);

			// Execute the stored procedure using FromSqlRaw
			var result = db.Questions
				//.FromSqlRaw("EXEC sp_ShowExamAnswers @Exam_id", param1)
				.FromSqlRaw("EXEC sp_ShowExamAnswers @Exam_id", param1)
				.ToList();
			foreach (var question in result)
			{
				db.Entry(question).Collection(x => x.Choices).Load();
			}

			return result;
		}

		//	public List<Choice> GetQuestionAnswers(int q_id)
		//{
		//	// Create parameters for the stored procedure
		//	var param1 = new SqlParameter("@id", q_id);

		//	// Execute the stored procedure using FromSqlRaw
		//	var result = db.Choices
		//		.FromSqlRaw("EXEC sp_GetAllChoicsPerQuetion @id", param1)
		//		.ToList();

		//	return result;
		//}
	}
}
