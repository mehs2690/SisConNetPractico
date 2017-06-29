using MehsBugsWebApp.Managers;
using MehsBugsWebApp.Models;
using System.Web.Mvc;

namespace MehsBugsWebApp.Controllers
{
    public class HomeController : Controller
    {
        [AllowAnonymous]
        public ActionResult Index(string msg)
        {
            if (!string.IsNullOrEmpty(msg))
            {
                ViewBag.MsgLogin = msg;
            }
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Validate(ModLogin request)
        {
            string status = "Credenciales incorrectas, intente de nuevo";
            if (ModelState.IsValid)
            {
                request.Mail = request.UserName;

                if (UserManager.ValidateUser(request, Response))
                {
                    if (string.IsNullOrEmpty(request.RedirectUrl))
                    {
                        request.RedirectUrl = "/";
                    }
                    status = string.Empty;
                    return RedirectToAction("Index", "Default");
                }
                else
                {
                    return RedirectToAction("Index", new { msg = status });
                }
            }
            else
            {
                return RedirectToAction("Index", new { msg = status });
            }
        }
    }
}