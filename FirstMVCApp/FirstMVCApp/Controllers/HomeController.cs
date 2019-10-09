using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FirstMVCApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public string Welcome()
        {
            return "Welcome to my first MVC application";
        }

      /*  public string Welcomex(string name)
        {
            if (name == "")
            {
                return name + " Welcome to my first MVC application";
            }
            else
            {
                return name + ", Welcome to my first MVC application";
            }

        }
        */

        public ActionResult WelcomeX (string name)
        {
            if (name == "")
            {
                ViewBag.Message =name + " Welcome to my first MVC application";
            }
            else
            {
                ViewBag.Message= name + ", Welcome to my first MVC application";
            }
            
            return View();
        }

        public ActionResult Max (int value1, int value2)
        {
            ViewBag.Message =Math.Max(value1, value2);
            return View();
        }
    }
}