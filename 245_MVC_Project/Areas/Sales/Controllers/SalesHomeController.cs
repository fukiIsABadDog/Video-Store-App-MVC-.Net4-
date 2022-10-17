using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _245_MVC_Project.Areas.Sales.Controllers
{
    public class SalesHomeController : Controller
    {
        // GET: Sales/SalesHome
        
        public ActionResult Index()
        {
            ViewBag.test = "This is the sales home view";
            return View();
        }

        [Authorize(Roles = "Sales")]
        public ActionResult SalesOrder()
        {
            ViewBag.test = "This is the sales order view";
            return View();
        }
    }
}