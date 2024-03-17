using Examination_System_Web_App.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Examination_System_Web_App.Controllers
{
    public class StudentController : Controller
    {
        IStudentRepository stdrepo;
        IExamRepository examrepo;
        public StudentController(IStudentRepository _studentrepo , IExamRepository _examrepo)
        {
            stdrepo = _studentrepo;
            examrepo = _examrepo;
        }
        public IActionResult Index(int? id)
        {
            var model = stdrepo.GetStudent(id.Value);
            return View(model);
        }

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
            ViewBag.examid = id;
            ViewBag.stdid = stdid;

            return View();
        }
    }
}
