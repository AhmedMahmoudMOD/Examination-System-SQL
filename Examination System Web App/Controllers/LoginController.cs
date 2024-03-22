using Examination_System_Web_App.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Examination_System_Web_App.Controllers
{
    public class LoginController : Controller
    {
        private readonly IInstructorRepository instructorRepository;
        private readonly IStudentRepository studentRepository;

        public LoginController(IInstructorRepository instructorRepository , IStudentRepository studentRepository)
        {
            this.instructorRepository = instructorRepository;
            this.studentRepository = studentRepository;
        }
        public IActionResult StudentLogin()
        {
            return View();
        }

        public IActionResult InstLogin()
        {
            return View();
        }

        [HttpPost]
        public IActionResult StudentLogin(int id)
        {
            return View();
        }
        [HttpPost]
        public IActionResult InstLogin(string email , string pass)
        {
            //1 modelstate is valid 
            //2
             var inst = instructorRepository.GetInstructorLogin(email, pass);

            // check if null
            // if not null
            // set session instID = inst.ins_id
            // redirect to Instructor / index

            // if null 
            // retrun the same view with error

            
            return View();
        }
    }
}
