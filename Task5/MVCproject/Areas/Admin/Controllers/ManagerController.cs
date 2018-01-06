using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCproject.Models;
using System.Net;

using MVCproject.Controllers;


namespace MVCproject.Areas.Admin.Controllers
{
     
    public class ManagerController : BaseController
    {

    
        public ActionResult Index()
        {
            var sales = new DAL.Repository.ManagerRepository()
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
                .Select(y => new ManagerMVC() { Id = y.Id, Name = y.ManagerName })
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
                var item = new Modell.Manager() { Id = manager.Id, ManagerName = manager.Name };
                new DAL.Repository.ManagerRepository()
                    .Insert(item);

                return RedirectToAction("Index");
            }

            return PartialView(manager);
        }

      
        public ActionResult ManagerList()
        {
            var item = new DAL.Repository.ManagerRepository()
                .GetAll()
                .Select(x => new ManagerMVC() { Id = x.Id, Name = x.ManagerName });
            return PartialView("PartialManagerList", item);
        }

        // GET: Admin/Manager/Edit/5
    
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var managerId = id ?? default(int);

            var manager = new DAL.Repository.ManagerRepository()
                .GetById(managerId).Select(x => new ManagerMVC() { Id = x.Id, Name = x.ManagerName })
                .FirstOrDefault();

            if (manager == null)
            {
                return HttpNotFound();
            }
            return PartialView(manager);
        }

        // POST: Admin/Manager/Edit/5
        [HttpPost]
   
        public ActionResult Edit([Bind(Include = "Id,Name")] ManagerMVC manager)
        {
            if (ModelState.IsValid)
            {
                var item = new DAL.Repository.ManagerRepository()
                    .GetById(manager.Id)
                    .FirstOrDefault();

                if (item != null)
                {
                    item.ManagerName = manager.Name;
                    new DAL.Repository.ManagerRepository()
                        .Update(item);

                    return RedirectToAction("Index");
                }
            }
            return PartialView(manager);
        }

        // GET: Admin/Manager/Delete/5
       
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var managerId = id ?? default(int);

            var manager = new DAL.Repository.ManagerRepository()
                .GetById(managerId)
                .Select(m => new ManagerMVC() { Id = m.Id, Name = m.ManagerName })
                .FirstOrDefault();

            if (manager == null)
            {
                return HttpNotFound();
            }
            return PartialView(manager);
        }

        // POST: Admin/Manager/Delete/5
      
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
