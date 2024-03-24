using Examination_System_Web_App.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Examination_System_Web_App.Repositories
{
    public class InstructorRepository : IInstructorRepository
    {
        private readonly ExamSysContext db;

        public InstructorRepository(ExamSysContext db) {
            this.db = db;
        }

        public Instructor GetInstructorLogin(string email, string pass)
        {
            var target = db.Instructors.SingleOrDefault(d => d.ins_email == email && d.ins_password==pass);
            return target;
        }

        public Instructor GetByIDWithDepartments(int id)
        {
            var target = db.Instructors.Include(i=>i.Departments).SingleOrDefault(d=>d.ins_id == id);
            return target;   
        }

        public List<Course> GetCourses(int insId,int deptNo) {
            var instructor = db.Instructors.Include(ins => ins.Dept_inst_courses).ThenInclude(dic => dic.crs)
                               .FirstOrDefault(ins => ins.ins_id == insId);

            if (instructor != null)
            {
               

                var courses = instructor.Dept_inst_courses
                    .Where(dic => dic.dept_no == deptNo)
                    .Select(dic => dic.crs)
                    .Distinct()
                    .ToList();

                return courses;

            }
            else
            {
                throw new Exception("Exception");
            }
        }

        public List<Department> GetDepartments(int insId)
        {
            var instructor = db.Instructors.Include(ins => ins.Dept_inst_courses).ThenInclude(dic => dic.dept_noNavigation)
                               .FirstOrDefault(ins => ins.ins_id == insId);

            if (instructor != null)
            {

                var departments = instructor.Dept_inst_courses
                    .Select(dic => dic.dept_noNavigation)
                    .Distinct()
                    .ToList();

                return departments;

            }
            else
            {
                throw new Exception("Exception");
            }
        }

        
    }
}
