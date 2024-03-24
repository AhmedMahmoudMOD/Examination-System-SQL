using Examination_System_Web_App.Models;
using Examination_System_Web_App.Repositories;
using Examination_System_Web_App.View_Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Examination_System_Web_App.Controllers
{
    public class SupervisorController : Controller
    {
        private readonly IInstructorRepository instructorRepository;
        private readonly IDepartmentRepository departmentRepository;
        private readonly IStudentRepository studentRepository;

        public SupervisorController(IInstructorRepository instructorRepository, IDepartmentRepository departmentRepository, IStudentRepository studentRepository)
        {
            
            
                this.instructorRepository = instructorRepository;
                this.departmentRepository = departmentRepository;
                this.studentRepository = studentRepository;
            
        }
        public IActionResult Index()
        {
            int InsID = 1;
            var dept = departmentRepository.GetBySupId(InsID);
            var list = dept.Students.ToList();
            return View(list);
        }
        public IActionResult AddStudent(int deptNo)
        {
            ViewBag.deptNo = deptNo;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddStudent(Student student)
        {
            if (ModelState.IsValid)
            {
                studentRepository.Add(student);
                return RedirectToAction("Index");
            }else
            {
                return View(student);
            }
        }
        public IActionResult UpdateStudent(int stdId)
        {
            var model = studentRepository.GetStudent(stdId);
            ViewBag.Depts = departmentRepository.GetAll();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateStudent(Student student)
        {
            if (ModelState.IsValid)
            {
                studentRepository.Update(student);
                return RedirectToAction("Index");
            }
            else
            {
                return View(student);
            }
        }


        public IActionResult GetInstructors()
        {
            var list = instructorRepository.GetAll();
            return View("Instructors",list);
        }

        public IActionResult AddInstructor()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddInstructor(Instructor instructor)
        {
            if (ModelState.IsValid)
            {
                instructorRepository.Add(instructor);
                return RedirectToAction("GetInstructors");
            }
            else
            {
                return View(instructor);
            }
        }

        public IActionResult UpdateInstructor(int insId)
        {
            var model = instructorRepository.GetByIDWithDepartments(insId);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateInstructor(Instructor instructor)
        {
            if (ModelState.IsValid)
            {
                instructorRepository.Update(instructor);
                return RedirectToAction("GetInstructors");
            }
            else
            {
                return View(instructor);
            }
        }
    }
}
