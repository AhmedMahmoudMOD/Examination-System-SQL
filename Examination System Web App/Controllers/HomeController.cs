using Examination_System_Web_App.AuthFilter;
using Examination_System_Web_App.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Examination_System_Web_App.Controllers
{
    
    public class HomeController : Controller
    {
        [AuthFilter]
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
