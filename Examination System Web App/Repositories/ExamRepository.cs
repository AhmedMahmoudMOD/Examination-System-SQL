using Examination_System_Web_App.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;

namespace Examination_System_Web_App.Repositories
{
    public class ExamRepository : IExamRepository
    {
        private readonly ExamSysContext db;
        public ExamRepository(ExamSysContext _db)
        {
            db = _db;
        }


        public List<Exam> GetAll()
        {
            var model = db.Exams.ToList();
            return model;
        }

        public List<Exam> GetAllForDepartmentToday(int id ,int stdid)
        {
            var degrees = db.Std_courses.Where(x=>x.std_id==stdid && x.grade.HasValue).Select(x=>x.crs_id).ToList();

            var model = db.Exams.Include(y => y.crs)
                .Include(z=>z.dept_noNavigation)
                .Where(x=>x.dept_no== id&& x.exam_date.HasValue && x.exam_date.Value.Date==DateTime.Today&&!degrees.Contains(x.crs_id.Value)).ToList();
            return model;
        }
    }
}
