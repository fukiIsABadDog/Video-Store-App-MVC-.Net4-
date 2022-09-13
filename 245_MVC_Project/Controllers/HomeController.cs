using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _245_MVC_Project.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            string name = "Justin";
            ViewBag.Date = DateTime.Now.ToString("MMM-dd");

            return View((object)name); // strings must be casted as another type -- not to confuse the view directory 
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}