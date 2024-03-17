using Examination_System_Web_App.Models;

namespace Examination_System_Web_App.Repositories
{
    public interface IExamRepository
    {
        public List<Exam> GetAll();
        public List<Exam> GetAllForDepartmentToday(int id , int stdid);


    }
}
