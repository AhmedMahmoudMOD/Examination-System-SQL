using Examination_System_Web_App.Models;

namespace Examination_System_Web_App.Repositories
{
    public interface IExamRepository
    {
        public List<Exam> GetAll();
        public List<Exam> GetAllForDepartmentToday(int id , int stdid);
        public List<Exam> GetAllForPastExams(int id, int stdid);


        public Task<int> ExamGeneration(int crsId, int deptNo, string name, int mcqNo, int tfNo, int duration, DateTime date);
    }
}
