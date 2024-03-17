using Examination_System_Web_App.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Examination_System_Web_App.Controllers
{
    public class StudentController : Controller
    {
        public static int counter = 0;
        IStudentRepository stdrepo;
        IExamRepository examrepo;
        public StudentController(IStudentRepository _studentrepo, IExamRepository _examrepo)
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
            if (id == null)
            {
                return RedirectToAction("index", "login");
            }
            int dept_no = (int)stdrepo.GetStudent(id.Value).dept_no;
            var model = examrepo.GetAllForDepartmentToday(dept_no, id.Value);
            if (model == null)
            {
                return Content("it appears there no exams due For Today");
            }
            ViewBag.stdid = stdrepo.GetStudent(id.Value).std_id;
            return View(model);
        }

        public IActionResult show_exam(int id, int stdid)
        {
            ViewBag.counter = counter;
            ViewBag.examid = id;
            ViewBag.stdid = stdid;

            var result = stdrepo.GetAllQuestions(id);
            
            result.Sort((x, y) => x.q_id.CompareTo(y.q_id));
            ViewBag.old = result[0].q_id-1;
            
            //var param2 = $"VALUES ({id}, {stdid}, 1, 'A')";
            //var result = stdrepo.FromSqlRaw("EXEC sp_showExamAnswer @param1, @param2", param1, param2).ToList();
            return View(result);
        }
    }
}
