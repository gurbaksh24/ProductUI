using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProductUserInterface.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            string userId = Request.Params["userid"];
            string pass = Request.Params["pass"];
            if(userId.Equals("user") && pass.Equals("pass"))
            {
                return RedirectToAction("WelcomeUser");
            }
            if (userId.Equals("admin") && pass.Equals("pass"))
            {
                return RedirectToAction("WelcomeAdmin");
            }
            TempData["Error"]="Invalid User Id or Password";
            return RedirectToAction("Index");
        }

        public ActionResult WelcomeUser ()
        {
            return View();
        }
        public ActionResult WelcomeAdmin()
        {
            return View();
        }
        public ActionResult Activity()
        {
            return View();
        }
        public ActionResult Air()
        {
            return View();
        }
        public ActionResult Car()
        {
            return View();
        }
        public ActionResult Hotel()
        {
            return View();
        }
    }
}