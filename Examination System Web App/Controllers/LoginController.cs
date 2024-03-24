using Examination_System_Web_App.Repositories;
using Examination_System_Web_App.View_Models;
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
        public IActionResult StudentLogin(LoginViewModel loginViewModel)
        {
            //first check if model state is valid
            if (!ModelState.IsValid)
            {
                return View(loginViewModel);
            }
            //second perform the Authentication
            var student = studentRepository.GetStudentLogin(loginViewModel.Email, loginViewModel.Password);
            //if Authentication success
            if (student != null)
            {
                //set the session
                HttpContext.Session.SetInt32("stdID", student.std_id);
                return RedirectToAction("Index", "Student", new { id = student.std_id });
            }
            //if Authentication failed
            else
            {
                TempData["ErrorMessage"] = "Invalid email or password.";
                return RedirectToAction(nameof(StudentLogin)); 

                //ModelState.AddModelError("Password", "Invalid Email or Password");
                //return View(loginViewModel);
            }
        }
        [HttpPost]
        public IActionResult InstLogin(LoginViewModel loginViewModel)
        {
            //first check if model state is valid
            if (!ModelState.IsValid)
            {
                return View(loginViewModel);
            }
            //second perform the Authentication
            var instructor = instructorRepository.GetInstructorLogin(loginViewModel.Email, loginViewModel.Password);
            
            //if Authentication success
            if (instructor != null)
            {
                //set the session
                HttpContext.Session.SetInt32("instID", instructor.ins_id);
                return RedirectToAction("Index", "Instructor");
            }
            //if Authentication failed
            else
            {
                ModelState.AddModelError("Password", "Invalid Email or Password");
                return View(loginViewModel);
            }
        }
        //Logout
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}
