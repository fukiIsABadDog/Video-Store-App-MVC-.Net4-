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
    public class PoItemsController : Controller
    {
        private InventoryEntities db = new InventoryEntities();

        // GET: Inventory/PoItems
        public ActionResult Index()
        {
            var poItems = db.PoItems.Include(p => p.Item).Include(p => p.PurchaseOrder);
            return View(poItems.ToList());
        }

        // GET: Inventory/PoItems/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PoItem poItem = db.PoItems.Find(id);
            if (poItem == null)
            {
                return HttpNotFound();
            }
            return View(poItem);
        }

        // GET: Inventory/PoItems/Create
        public ActionResult Create()
        {
            ViewBag.ItemId = new SelectList(db.Items, "ItemId", "Name");
            ViewBag.PurchaseOrderNumber = new SelectList(db.PurchaseOrders, "PurchaseOrderNumber", "PurchaseOrderNumber");
            return View();
        }

        // POST: Inventory/PoItems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PoItemId,PurchaseOrderNumber,ItemId,Quantity,Price")] PoItem poItem)
        {
            if (ModelState.IsValid)
            {
                db.PoItems.Add(poItem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ItemId = new SelectList(db.Items, "ItemId", "Name", poItem.ItemId);
            ViewBag.PurchaseOrderNumber = new SelectList(db.PurchaseOrders, "PurchaseOrderNumber", "PurchaseOrderNumber", poItem.PurchaseOrderNumber);
            return View(poItem);
        }

        // GET: Inventory/PoItems/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PoItem poItem = db.PoItems.Find(id);
            if (poItem == null)
            {
                return HttpNotFound();
            }
            ViewBag.ItemId = new SelectList(db.Items, "ItemId", "Name", poItem.ItemId);
            ViewBag.PurchaseOrderNumber = new SelectList(db.PurchaseOrders, "PurchaseOrderNumber", "PurchaseOrderNumber", poItem.PurchaseOrderNumber);
            return View(poItem);
        }

        // POST: Inventory/PoItems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PoItemId,PurchaseOrderNumber,ItemId,Quantity,Price")] PoItem poItem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(poItem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ItemId = new SelectList(db.Items, "ItemId", "Name", poItem.ItemId);
            ViewBag.PurchaseOrderNumber = new SelectList(db.PurchaseOrders, "PurchaseOrderNumber", "PurchaseOrderNumber", poItem.PurchaseOrderNumber);
            return View(poItem);
        }

        // GET: Inventory/PoItems/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PoItem poItem = db.PoItems.Find(id);
            if (poItem == null)
            {
                return HttpNotFound();
            }
            return View(poItem);
        }

        // POST: Inventory/PoItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PoItem poItem = db.PoItems.Find(id);
            db.PoItems.Remove(poItem);
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
