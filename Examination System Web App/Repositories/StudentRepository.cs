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

        public Student GetStudentLogin(string email, string pass)
        {
            var target = db.Students.SingleOrDefault(d => d.std_email == email && d.std_password == pass);
            return target;
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
		public void SumbitAnswers(int exam_id, int std_id, Dictionary<int, int> StdAnswers)
		{
			foreach (var item in StdAnswers)
			{
				var UpdatedData = new SqlParameter("@UpdatedData", $"answer ={item.Value} ");
				var condition = new SqlParameter("@condition", $"std_id ={std_id} AND exam_id = {exam_id} And q_id = {item.Key}");

				db.Database.ExecuteSqlRaw("EXEC sp_StudentAnswer_Update @UpdatedData, @condition", UpdatedData, condition);
			}
		}
		public void ExamCorrection(int ExamID, int StudentID)
		{
			var ExamIDParam = new SqlParameter("@ExamID", ExamID);
			var StudentIDParam = new SqlParameter("@StudentID", StudentID);
			db.Database.ExecuteSqlRaw("EXEC sp_CorrectExam @ExamID, @StudentID", ExamIDParam, StudentIDParam);
		}	
	}
}
