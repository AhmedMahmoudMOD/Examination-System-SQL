using Examination_System_Web_App.Models;

namespace Examination_System_Web_App.Repositories
{
    public interface IExamRepository
    {
         List<Exam> GetAll();
        List<Exam> GetAllForDepartmentToday(int id , int stdid);
        List<Exam> GetAllForPastExams(int id, int stdid);

        List<Exam> GetByCourseAndDept(int crsId, int deptNo);
         Task<int> ExamGeneration(int crsId, int deptNo, string name, int mcqNo, int tfNo, int duration, DateTime date);
    }
}
