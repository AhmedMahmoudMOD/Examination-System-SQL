using Examination_System_Web_App.Models;
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

        public Student GetStudent(int id)
        {
            var model = db.Students.Include(x=>x.Std_courses).ThenInclude(r=>r.crs).FirstOrDefault(x => x.std_id == id );
            return model;
        }

    }
}
