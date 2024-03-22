using Examination_System_Web_App.Models;
using Examination_System_Web_App.Repositories;
using Microsoft.AspNetCore.Mvc;

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

        public IActionResult AddStudent(Student student)
        {
            if (ModelState.IsValid)
            {
                studentRepository.Add(student);
                return RedirectToAction("Index");
            }else
            {
                return RedirectToAction("Index");
            }
        }


    }
}
