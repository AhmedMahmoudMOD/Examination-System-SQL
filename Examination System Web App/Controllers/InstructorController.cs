using Examination_System_Web_App.Models;
using Examination_System_Web_App.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Examination_System_Web_App.Controllers
{
    public class InstructorController : Controller
    {
        private readonly IInstructorRepository instructorRepository;

        public InstructorController(IInstructorRepository instructorRepository)
        {
            this.instructorRepository = instructorRepository;
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
    }
}
