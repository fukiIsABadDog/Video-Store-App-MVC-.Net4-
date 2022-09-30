using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _245_MVC_Project.Areas.Inventory.Controllers
{
    public class InventoryHomeController : Controller
    {
        // GET: Inventory/InventoryHome
        public ActionResult Index()
        {
            return View();
        }
    }
}