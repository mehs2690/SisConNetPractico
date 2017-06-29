using MehsBugsWebApp.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MehsBugsWebApp.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {
            //Profile.Tema = "";
            return View();
        }

        public ActionResult LogOut()
        {
            UserManager.Logoff(Session, Response);
            return RedirectToAction("Index", "Home");
        }
    }
}