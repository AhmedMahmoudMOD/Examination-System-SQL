using Examination_System_Web_App.Models;

namespace Examination_System_Web_App.Repositories
{
    public interface IStudentRepository
    {
        public Student GetStudent(int id);
        public List<Question> GetAllQuestions(int Exam_id);
    }
}
