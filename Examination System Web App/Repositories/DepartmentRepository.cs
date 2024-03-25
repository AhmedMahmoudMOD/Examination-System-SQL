using Examination_System_Web_App.Models;
using Microsoft.EntityFrameworkCore;

namespace Examination_System_Web_App.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly ExamSysContext db;

        public DepartmentRepository(ExamSysContext db)
        {
            this.db = db;
        }

        public List<Department> GetAll()
        {
            return db.Departments.ToList();
        }
        public List<Student> GetStudentsPerDept(int deptNo)
        {
            var dept = db.Departments.Include(d=>d.Students).SingleOrDefault(d=>d.dept_no == deptNo);

            var list = dept.Students.ToList();

            return list;

        }

        public Department GetBySupId(int supId)
        {
            var dept = db.Departments.Include(d=>d.Students).SingleOrDefault(d=>d.sup_id == supId);
            return dept;
        }
    }
}
