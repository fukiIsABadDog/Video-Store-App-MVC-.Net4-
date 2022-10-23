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
    public class SpoilagesController : Controller
    {
        private InventoryEntities db = new InventoryEntities();

        // GET: Inventory/Spoilages
        public ActionResult Index()
        {
            var spoilages = db.Spoilages.Include(s => s.Item);
            return View(spoilages.ToList());
        }

        // GET: Inventory/Spoilages/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Spoilage spoilage = db.Spoilages.Find(id);
            if (spoilage == null)
            {
                return HttpNotFound();
            }
            return View(spoilage);
        }

        // GET: Inventory/Spoilages/Create
        public ActionResult Create()
        {
            ViewBag.ItemId = new SelectList(db.Items, "ItemId", "Name");
            return View();
        }

        // POST: Inventory/Spoilages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SpoilageId,ItemId,Quantity,ReasonType,Description,SpoilageDate,Value")] Spoilage spoilage)
        {
            if (ModelState.IsValid)
            {
                db.Spoilages.Add(spoilage);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ItemId = new SelectList(db.Items, "ItemId", "Name", spoilage.ItemId);
            return View(spoilage);
        }

        // GET: Inventory/Spoilages/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Spoilage spoilage = db.Spoilages.Find(id);
            if (spoilage == null)
            {
                return HttpNotFound();
            }
            ViewBag.ItemId = new SelectList(db.Items, "ItemId", "Name", spoilage.ItemId);
            return View(spoilage);
        }

        // POST: Inventory/Spoilages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SpoilageId,ItemId,Quantity,ReasonType,Description,SpoilageDate,Value")] Spoilage spoilage)
        {
            if (ModelState.IsValid)
            {
                db.Entry(spoilage).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ItemId = new SelectList(db.Items, "ItemId", "Name", spoilage.ItemId);
            return View(spoilage);
        }

        // GET: Inventory/Spoilages/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Spoilage spoilage = db.Spoilages.Find(id);
            if (spoilage == null)
            {
                return HttpNotFound();
            }
            return View(spoilage);
        }

        // POST: Inventory/Spoilages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Spoilage spoilage = db.Spoilages.Find(id);
            db.Spoilages.Remove(spoilage);
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
