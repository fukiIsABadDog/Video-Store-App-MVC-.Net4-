using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _245_MVC_Project.Models;

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
            var about = new About { Age = 30, FirstName = "Justin", LastName = "Ansardi",YearsExp = 1.5};


            return View(about);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}