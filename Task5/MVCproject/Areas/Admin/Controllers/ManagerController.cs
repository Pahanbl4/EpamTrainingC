using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCproject.Models;
using System.Net;
using Modell;
using MVCproject.Controllers;
using DAL.Repository;

namespace MVCproject.Areas.Admin.Controllers
{
     
    public class ManagerController : BaseController
    {

    
        public ActionResult Index()
        {
            var sales = new ManagerRepository()
                .GetAll()
                .GroupBy(p => p.ManagerName.Substring(0, 1))
                .Select(p => new { k = p.Key, value = p })
                .ToDictionary(
                    p => p.k,
                    p => p.value.Select(
                        x => new MVCproject.Models.ManagerMVC
                        { Id = x.Id, Name = x.ManagerName }));
           

            return View(sales);
        }

    
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var managerId = id ?? default(int);

            var manager = new DAL.Repository.ManagerRepository()
                .GetById(managerId)
                .Select(y => new Manager() { Id = y.Id, ManagerName = y.ManagerName })
                .FirstOrDefault();

            if (manager == null)
            {
                return HttpNotFound();
            }
            return PartialView(manager);
        }

        // GET: Admin/Manager/Create
    
        public ActionResult Create()
        {
            return PartialView();
        }

        // POST: Admin/Manager/Create

        [HttpPost]
        public ActionResult Create([Bind(Include = "Id,Name")] Models.ManagerMVC manager)
        {
            if (ModelState.IsValid)
            {
                var item = new Manager() { Id = manager.Id, ManagerName = manager.Name };
                new DAL.Repository.ManagerRepository()
                    .Insert(item);

                return RedirectToAction("Index");
            }

            return PartialView(manager);
        }

        [AjaxOnly]
        [HttpGet]
        public ActionResult ManagerList()
        {
            var item = new DAL.Repository.ManagerRepository()
                .GetAll()
                .Select(x => new Manager() { Id = x.Id, ManagerName = x.ManagerName });
            return PartialView("PartialManagerList", item);
        }

        // GET: Admin/Manager/Edit/5
        [AjaxOnly]
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var managerId = id ?? default(int);

            var manager = new DAL.Repository.ManagerRepository()
                .GetById(managerId).Select(x => new Manager() { Id = x.Id, ManagerName = x.ManagerName })
                .FirstOrDefault();

            if (manager == null)
            {
                return HttpNotFound();
            }
            return PartialView(manager);
        }

        // POST: Admin/Manager/Edit/5
        [HttpPost]
        [AjaxOnly]
        public ActionResult Edit([Bind(Include = "Id,ManagerName")] Manager manager)
        {
            if (ModelState.IsValid)
            {
                var item = new DAL.Repository.ManagerRepository()
                    .GetById(manager.Id)
                    .FirstOrDefault();

                if (item != null)
                {
                    item.ManagerName = manager.ManagerName;
                    new DAL.Repository.ManagerRepository()
                        .Update(item);

                    return RedirectToAction("Index");
                }
            }
            return PartialView(manager);
        }

        // GET: Admin/Manager/Delete/5
        [AjaxOnly]
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var managerId = id ?? default(int);

            var manager = new DAL.Repository.ManagerRepository()
                .GetById(managerId)
                .Select(m => new Manager() { Id = m.Id, ManagerName = m.ManagerName })
                .FirstOrDefault();

            if (manager == null)
            {
                return HttpNotFound();
            }
            return PartialView(manager);
        }

        // POST: Admin/Manager/Delete/5
        [ValidateAntiForgeryToken]
        [HttpPost, ActionName("Delete")]

        public ActionResult DeleteConfirmed(int id)
        {
            var manager = new DAL.Repository.ManagerRepository()
                .GetById(id)
                .FirstOrDefault();

            new DAL.Repository.ManagerRepository()
                .Remove(manager);

            return RedirectToAction("Index");
        }

        
       

        
    }
}
