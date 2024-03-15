using Examination_System_Web_App.Models;
using Examination_System_Web_App.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Examination_System_Web_App.Controllers
{
    public class InstructorController : Controller
    {
        private readonly IInstructorRepository instructorRepository;
        private readonly IStudentCourseRepository studentCourseRepository;

        public InstructorController(IInstructorRepository instructorRepository , IStudentCourseRepository studentCourseRepository)
        {
            this.instructorRepository = instructorRepository;
            this.studentCourseRepository = studentCourseRepository;
        }
        public IActionResult Index()
        {
            int InsID = 1;
            var Depts = instructorRepository.GetDepartments(InsID);
            ViewBag.Depts = Depts;
            int stDeptNo = Depts[0].dept_no;
            ViewBag.Courses = instructorRepository.GetCourses(InsID,stDeptNo);
            return View();
        }

        public IActionResult RenderCourses(int deptNo)
        {

            int InsID = 1;
            int stDeptNo = deptNo;
            ViewBag.Courses = instructorRepository.GetCourses(InsID, stDeptNo);
            return PartialView("_CoursesTablePartial");
        }

        public IActionResult GetCourseGrades(int crsId,int deptNo)
        {
            var List = studentCourseRepository.GetByCourseID(crsId,deptNo);

            return PartialView("_CouesesGradesPartial", List);
        }
    }
}
