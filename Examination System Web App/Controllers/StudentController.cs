using Examination_System_Web_App.Models;
using Examination_System_Web_App.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.HttpSys;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using NuGet.Protocol.Plugins;
using System.Threading;
using System.Timers;

namespace Examination_System_Web_App.Controllers
{
	public class StudentController : Controller
	{
		public static int counter = 0;
		private System.Timers.Timer timer;
		IStudentRepository stdrepo;
		IExamRepository examrepo;
		IStudentCourseRepository studentcourserepo;
		public StudentController(IStudentRepository _studentrepo, IExamRepository _examrepo, IStudentCourseRepository _studentcourserepo)
		{
			stdrepo = _studentrepo;
			examrepo = _examrepo;
			studentcourserepo = _studentcourserepo;
		}
		public IActionResult Index(int? id)
		{
			int? stdid = HttpContext.Session.GetInt32("stdID");

			if (stdid == null)
			{
				return Unauthorized();
			}

			var model = studentcourserepo.GetStudentDegrees(id.Value);
			ViewBag.student = stdrepo.GetStudent(id.Value);
			return View(model);
		}
		//comment new things
		public IActionResult exams(int? id)
		{

			int? stdid = HttpContext.Session.GetInt32("stdID");

			if (stdid == null)
			{
				return Unauthorized();
			}

			if (id == null)
			{
				return RedirectToAction("index", "login");
			}
			int dept_no = (int)stdrepo.GetStudent(id.Value).dept_no;
			var model = examrepo.GetAllForDepartmentToday(dept_no, id.Value);
			ViewBag.pastexams = examrepo.GetAllForPastExams(dept_no, id.Value);
			//return Content($"{id.Value}");
			if (model == null)
			{
				return Content("it appears there no exams due For Today");
			}
			ViewBag.stdid = stdrepo.GetStudent(id.Value).std_id;
			return View(model);
		}


		public IActionResult show_exam(int id, int stdid)
		{
			int? stdid1 = HttpContext.Session.GetInt32("stdID");

			if (stdid1 == null)
			{
				return Unauthorized();
			}

			Exam exam = examrepo.getById(id);
			ViewBag.exam = exam;
			ViewBag.ExamDuration = (int)exam.exam_duration * 60;
			ViewBag.counter = counter;
			ViewBag.examid = id;
			ViewBag.stdid = stdid;

			var result = stdrepo.GetAllQuestions(id);

			result.Sort((x, y) => x.q_id.CompareTo(y.q_id));
			ViewBag.old = result[0].q_id - 1;

			return View(result);
		}
		[HttpPost]
		public IActionResult ExamSumbitted(int stdid, int examid, Dictionary<int, int> studentAnswers)
		{
			int? stdid1 = HttpContext.Session.GetInt32("stdID");

			if (stdid1 == null)
			{
				return Unauthorized();
			}

			stdrepo.SumbitAnswers(examid, stdid, studentAnswers);
			stdrepo.ExamCorrection(examid, stdid);
			return RedirectToAction("exams", new { id = stdid });
		}

	}
}
