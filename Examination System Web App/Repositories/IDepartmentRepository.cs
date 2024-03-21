using Examination_System_Web_App.Models;

namespace Examination_System_Web_App.Repositories
{
    public interface IDepartmentRepository
    {
        List<Student> GetStudentsPerDept(int deptNo);

        Department GetBySupId(int supId);
    }
}
