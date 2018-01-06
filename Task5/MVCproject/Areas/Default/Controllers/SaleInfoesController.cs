using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Modell;

namespace MVCproject.Areas.Default.Controllers
{
    public class SaleInfoesController : Controller
    {
        private ModelDataEntities2 db = new ModelDataEntities2();

        // GET: Default/SaleInfoes
        public ActionResult Index(string sortBy, string search)
        {
            ViewBag.SortManagerNameParameter = string.IsNullOrEmpty(sortBy) ? "ManagerName" : "";
            ViewBag.SortProductNameParameter = string.IsNullOrEmpty(sortBy) ? "ProductName" : "";
            ViewBag.SortClientNameParameter = string.IsNullOrEmpty(sortBy) ? "ClientName" : "";

            var saleInfo = db.SaleInfo.AsQueryable();

      switch (sortBy)
            {
                case "ManagerName desc":
                    saleInfo = saleInfo.OrderByDescending(x => x.Manager.ManagerName);
                    break;
                case "ProductName desc":
                    saleInfo = saleInfo.OrderByDescending(x => x.Product.ProductName);
                    break;
                case "ProductName":
                    saleInfo = saleInfo.OrderBy(x => x.Product.ProductName);
                    break;

                case "ClientName desc":
                    saleInfo = saleInfo.OrderByDescending(x => x.Client.ClientName);
                    break;
                case "ClientName":
                    saleInfo = saleInfo.OrderBy(x => x.Client.ClientName);
                    break;
                case "ManagerName":
                    saleInfo = saleInfo.OrderBy(x => x.Manager.ManagerName);
                    break;
            }
            
            return View(saleInfo.ToList());
        }

        // GET: Default/SaleInfoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SaleInfo saleInfo = db.SaleInfo.Find(id);
            if (saleInfo == null)
            {
                return HttpNotFound();
            }
            return View(saleInfo);
        }

        // GET: Default/SaleInfoes/Create
        public ActionResult Create()
        {
            ViewBag.ID_Client = new SelectList(db.Client, "Id", "ClientName");
            ViewBag.ID_Manager = new SelectList(db.Manager, "Id", "ManagerName");
            ViewBag.ID_Product = new SelectList(db.Product, "Id", "ProductName");
            return View();
        }

        // POST: Default/SaleInfoes/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Dato,Sum,ID_Manager,ID_Client,ID_Product")] SaleInfo saleInfo)
        {
            if (ModelState.IsValid)
            {
                db.SaleInfo.Add(saleInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_Client = new SelectList(db.Client, "Id", "ClientName", saleInfo.ID_Client);
            ViewBag.ID_Manager = new SelectList(db.Manager, "Id", "ManagerName", saleInfo.ID_Manager);
            ViewBag.ID_Product = new SelectList(db.Product, "Id", "ProductName", saleInfo.ID_Product);
            return View(saleInfo);
        }

        // GET: Default/SaleInfoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SaleInfo saleInfo = db.SaleInfo.Find(id);
            if (saleInfo == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Client = new SelectList(db.Client, "Id", "ClientName", saleInfo.ID_Client);
            ViewBag.ID_Manager = new SelectList(db.Manager, "Id", "ManagerName", saleInfo.ID_Manager);
            ViewBag.ID_Product = new SelectList(db.Product, "Id", "ProductName", saleInfo.ID_Product);
            return View(saleInfo);
        }

        // POST: Default/SaleInfoes/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Dato,Sum,ID_Manager,ID_Client,ID_Product")] SaleInfo saleInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(saleInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Client = new SelectList(db.Client, "Id", "ClientName", saleInfo.Client.ClientName);
            ViewBag.ID_Manager = new SelectList(db.Manager, "Id", "ManagerName", saleInfo.ID_Manager);
            ViewBag.ID_Product = new SelectList(db.Product, "Id", "ProductName", saleInfo.ID_Product);
            return View(saleInfo);
        }

        // GET: Default/SaleInfoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SaleInfo saleInfo = db.SaleInfo.Find(id);
            if (saleInfo == null)
            {
                return HttpNotFound();
            }
            return View(saleInfo);
        }

        // POST: Default/SaleInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SaleInfo saleInfo = db.SaleInfo.Find(id);
            db.SaleInfo.Remove(saleInfo);
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
