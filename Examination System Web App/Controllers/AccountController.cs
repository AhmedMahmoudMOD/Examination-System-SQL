using Examination_System_Web_App.Models;
using Examination_System_Web_App.View_Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp;
using System.Security.Claims;

namespace Examination_System_Web_App.Controllers
{
    public class AccountController : Controller
    {
        //connect to the database
        public AccountController(ExamSysContext _ExamSys)
        {
            ExamSystem = _ExamSys;
        }

        public ExamSysContext ExamSystem; //{ get; }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult>Login(LoginViewModel model)
        {
            //cheack if the model is valid
            //connect to the database
            //to know if the user is valid
            //need to make repository
            if(!ModelState.IsValid)
            {
                return View(model);
            }
            var user= ExamSystem.Users.FirstOrDefault(x => x.Email == model.Email && x.Password == model.Password);
            if (user == null)
            {
                ModelState.AddModelError("", "Invalid Email or Password");
                return View();
            }
            // we need Email and Name to be stored in the cookie with every request
            Claim claim1 = new Claim(ClaimTypes.Email, user.Email); 
            //there is error here with null exception

            Claim claim2 = new Claim(ClaimTypes.Name, user.Name);
            // we will make card to store the claims
            //ClaimsIdentity identity = new ClaimsIdentity(new[] { claim1, claim2 }, "cookie");
            ClaimsIdentity identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
            identity.AddClaim(claim1);
            identity.AddClaim(claim2);
            ClaimsPrincipal principal = new ClaimsPrincipal(identity);
            principal.AddIdentity(identity);
            //save the data in the cookie
            await HttpContext.SignInAsync(principal);
            // redirect to the home page
            return RedirectToAction("Index", "Home");



        }
    }
}
