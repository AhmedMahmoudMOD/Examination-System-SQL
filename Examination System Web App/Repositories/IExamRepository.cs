namespace Examination_System_Web_App.Repositories
{
    public interface IExamRepository
    {

        public  Task<int> ExamGeneration(int crsId, int deptNo, string name, int mcqNo, int tfNo, int duration, DateTime date);
    }
}
