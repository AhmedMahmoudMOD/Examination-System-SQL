using Microsoft.AspNetCore.Mvc;

namespace Examination_System_Web_App.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
    }
}
