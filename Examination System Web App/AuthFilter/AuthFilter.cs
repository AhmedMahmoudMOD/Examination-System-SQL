using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Examination_System_Web_App.AuthFilter
{
    public class AuthFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.HttpContext.User.Identity.IsAuthenticated == false)
            {

                context.Result = new RedirectToActionResult("Login", "Account", null);
            }
            else
            {
                base.OnActionExecuting(context);
            }
        }
    }
}
