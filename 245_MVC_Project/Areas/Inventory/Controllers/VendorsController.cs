using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ITP245_Model;

namespace _245_MVC_Project.Areas.Inventory.Controllers
{
    public class VendorsController : Controller
    {
        private InventoryEntities db = new InventoryEntities();

        // GET: Inventory/Vendors
        public ActionResult Index()
        {
            ViewBag.State = new SelectList(db.Vendors.OrderBy(v => v.State),"State","State"); //may need different arguments
            var vendors = db.Vendors.Select(v => v).ToList();
            return View(vendors);

        }

        // returns vendors by state partial view
        public ActionResult _IndexByTag(string state)
        {
            db.Configuration.ProxyCreationEnabled = false;

            if (state == "showAll")
            {
                var allVendors = db.Vendors.Select(v => v).ToArray();
                return PartialView("_Index",allVendors);
            }
            else
            {
                var vendors = db.Vendors.Select(v => v).Where(v => v.State.Equals(state)).ToArray();
                return PartialView("_Index", vendors);
            }        
        }

        // GET: Inventory/Vendors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vendor vendor = db.Vendors.Find(id);
            if (vendor == null)
            {
                return HttpNotFound();
            }
            return View(vendor);
        }

        // GET: Inventory/Vendors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Inventory/Vendors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VendorId,Name,Address1,Address2,City,State,ZipCode,PhoneNumber,Email,Contact")] Vendor vendor)
        {
            if (ModelState.IsValid)
            {
                db.Vendors.Add(vendor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vendor);
        }

        // GET: Inventory/Vendors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vendor vendor = db.Vendors.Find(id);
            if (vendor == null)
            {
                return HttpNotFound();
            }
            return View(vendor);
        }

        // POST: Inventory/Vendors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VendorId,Name,Address1,Address2,City,State,ZipCode,PhoneNumber,Email,Contact")] Vendor vendor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vendor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vendor);
        }

        // GET: Inventory/Vendors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vendor vendor = db.Vendors.Find(id);
            if (vendor == null)
            {
                return HttpNotFound();
            }
            return View(vendor);
        }

        // POST: Inventory/Vendors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vendor vendor = db.Vendors.Find(id);
            db.Vendors.Remove(vendor);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
