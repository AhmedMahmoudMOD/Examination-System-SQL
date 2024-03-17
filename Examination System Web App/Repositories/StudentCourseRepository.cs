using Examination_System_Web_App.Models;
using Microsoft.EntityFrameworkCore;

namespace Examination_System_Web_App.Repositories
{
    public class StudentCourseRepository : IStudentCourseRepository
    {
        private readonly ExamSysContext db;

        public StudentCourseRepository(ExamSysContext db)
        {
            this.db = db;
        }

        public List<Std_course> GetByCourseID(int courseID,int DeptNo) { 
            var list = db.Std_courses.Include(sc=>sc.std).Where(sc=>sc.crs_id == courseID&&sc.std.dept_no==DeptNo).ToList();

            return list;
        
        }
    }
}
