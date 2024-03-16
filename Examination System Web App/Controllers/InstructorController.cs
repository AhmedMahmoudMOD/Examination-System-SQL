using Microsoft.AspNetCore.Mvc;

namespace Examination_System_Web_App.Controllers
{
    public class InstructorController : Controller
    {
        public InstructorController()
        {
            
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddQuestion()
        {
            return View();
        }

    }
}
