using Examination_System_Web_App.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Examination_System_Web_App.Controllers
{
    public class StudentController : Controller
    {
        IStudentRepository stdrepo;
        IExamRepository examrepo;
        IStudentCourseRepository studentcourserepo;
        public StudentController(IStudentRepository _studentrepo , IExamRepository _examrepo , IStudentCourseRepository _studentcourserepo)
        {
            stdrepo = _studentrepo;
            examrepo = _examrepo;
           studentcourserepo = _studentcourserepo;
        }
        public IActionResult Index(int? id)
        {
            var model = studentcourserepo.GetStudentDegrees(id.Value);
            ViewBag.student =  stdrepo.GetStudent(id.Value);
            return View(model);
        }
        //thing
        public IActionResult exams(int? id)
        {
            if(id==null)
            {
                return RedirectToAction("index", "login");
            }
            int dept_no = (int) stdrepo.GetStudent(id.Value).dept_no;
            var model = examrepo.GetAllForDepartmentToday(dept_no , id.Value);
            if(model == null)
            {
                return Content("it appears there no exams due For Today");
            }
            ViewBag.stdid = stdrepo.GetStudent(id.Value).std_id;
            return View (model);
        }

        public IActionResult show_exam(int id, int stdid)
        {
            return Content($"{id}::{stdid}");
        }
    }
}
