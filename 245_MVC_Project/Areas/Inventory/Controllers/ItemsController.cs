using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using _245_MVC_Project.Models;
using ITP245_Model;

namespace _245_MVC_Project.Areas.Inventory.Controllers
{
    public class ItemsController : Controller
    {
        private InventoryEntities db = new InventoryEntities();

        // GET: Inventory/Items
        public ActionResult Index()
        {
            ViewBag.CategoryId = new SelectList(db.Categories.OrderBy(c => c.Name),"CategoryId","Name");
            var items = db.Items.Include(i => i.Category);
            return View(items.ToList());
        }

        public ActionResult _IndexByTag(int id)
        {
            db.Configuration.ProxyCreationEnabled = false;
            var items = db.Items.Include(i=>i.Category).Where(i=>i.CategoryId.Equals(id)).ToArray();
            return PartialView("_Index",items);
        }

        public ActionResult _IndexByName(string parm)
        {
            var items = db.Items.Include(i => i.Category).Where(i=>i.Name.Contains(parm)).ToArray();
            return PartialView("_Index", items);
        }
        // GET: Inventory/Items/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = db.Items.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // GET: Inventory/Items/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Name");
            return View();
        }

        // POST: Inventory/Items/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ItemId,CategoryId,Name,Description,QuantityOnHand,RetailPrice,StandardCost,ImageLocation,FileName")] Item item)
        {
            if (ModelState.IsValid)
            {
                db.Items.Add(item);
                if(item.FileName != null)
                {
                    item.ImageLocation = UploadImage(item.FileName);
                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Name", item.CategoryId);
            return View(item);
        }
        private string UploadImage(HttpPostedFileBase file)
        {
            if (Request.Files.Count > 0)
            {
                try
                {
                    var allowedExtensions = new[] { ".JPG", ".JPEG", ".PNG", ".jpg", ".jpeg", ".png"};
                    var imagePath = ConfigurationManager.AppSettings["ItemImage"];
                    var mapPath = HttpContext.Server.MapPath(imagePath);
                    string path = Path.Combine(mapPath, Path.GetFileName(file.FileName));
                    string ext = Path.GetExtension(file.FileName);
                    if (allowedExtensions.Contains(ext))
                    {
                        file.SaveAs(path);
                        ViewBag.Message = "File uploaded successfully";
                        return $"{imagePath}/{file.FileName}";
                    }
                }
                catch(Exception ex)
                {
                    ViewBag.Message = $"ERROR: {ex.Message}";
                }
                
            }

            return String.Empty;
        }

        // GET: Inventory/Items/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = db.Items.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Name", item.CategoryId);
            return View(item);
        }

        // POST: Inventory/Items/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ItemId,CategoryId,Name,Description,QuantityOnHand,RetailPrice,StandardCost,ImageLocation,FileName")] Item item)
        {
            if (ModelState.IsValid) //TESTING 12/5 FOR IMAGE EDIT
            {
                db.Entry(item).State = EntityState.Modified;
                if (item.FileName != null)
                {
                    item.ImageLocation = UploadImage(item.FileName);
            }
            db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Name", item.CategoryId);
            return View(item);
        }

        // GET: Inventory/Items/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = db.Items.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // POST: Inventory/Items/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Item item = db.Items.Find(id);
            db.Items.Remove(item);
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
