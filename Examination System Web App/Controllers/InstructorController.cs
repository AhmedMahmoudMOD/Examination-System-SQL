using Examination_System_Web_App.Models;
using Examination_System_Web_App.Repositories;
using Examination_System_Web_App.View_Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Examination_System_Web_App.Controllers
{
    public class InstructorController : Controller
    {
        private readonly IInstructorRepository instructorRepository;
        private readonly IStudentCourseRepository studentCourseRepository;
        private readonly IQuestionRepository questionRepository;
        private readonly IChoiceRepository choiceRepository;

        public InstructorController(IInstructorRepository instructorRepository , IStudentCourseRepository studentCourseRepository , IQuestionRepository questionRepository , IChoiceRepository choiceRepository)
        {
            this.instructorRepository = instructorRepository;
            this.studentCourseRepository = studentCourseRepository;
            this.questionRepository = questionRepository;
            this.choiceRepository = choiceRepository;
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

        public IActionResult AddQuestion(int crsId)
        {
            ViewBag.CourseID = crsId;
            return View();
        }


        [HttpPost]
        public IActionResult AddMCQ(QuestionWithChoicesVM question)
        {
            if (ModelState.IsValid) { 
            Question q = new Question() { crs_id = question.CrsId, q_type="MCQ" , q_text=question.Q_Text , q_modalanswer=question.ModelAnswer , q_score=question.Q_Score };
            questionRepository.Add(q);

            q.Choices.Add(new Choice { q_id=q.q_id, ch_no = 1, ch_text = question.Choice_1 });
            q.Choices.Add(new Choice { q_id = q.q_id, ch_no = 2, ch_text = question.Choice_2 });
            q.Choices.Add(new Choice {q_id = q.q_id, ch_no = 3, ch_text = question.Choice_3 });
            q.Choices.Add(new Choice { q_id = q.q_id, ch_no = 4, ch_text = question.Choice_4 });
            questionRepository.Update(q);
            return RedirectToAction("Index");
            }
            else
            {
                ViewBag.CourseID = question.CrsId;
                return View("AddQuestion",question);
            }
        }

        [HttpPost]
        public IActionResult AddTorF(QuestionTorFVM question)
        {

            if (ModelState.IsValid)
            {
                Question q = new Question() { crs_id = question.CrsId, q_type = "T/F", q_text = question.Q_Text, q_modalanswer = question.ModelAnswer, q_score = question.Q_Score };
                questionRepository.Add(q);

                q.Choices.Add(new Choice { q_id = q.q_id, ch_no = 1, ch_text = "True" });
                q.Choices.Add(new Choice { q_id = q.q_id, ch_no = 2, ch_text = "False" });
                questionRepository.Update(q);
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.CourseID = question.CrsId;
                return View("AddQuestion", question);
            }
           
        }
    }
}
