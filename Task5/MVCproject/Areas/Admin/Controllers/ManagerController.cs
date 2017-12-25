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
        


        [HttpGet]
        public ActionResult Index()
        {


            //var list = saleInfoRepository.Items.OrderByDescending(x => x.ID_Sale);
           


            var sales = new ManagerRepository()
                .GetAll()
                .GroupBy(p => p.ManagerName.Substring(0, 1))
                .Select(p => new { k = p.Key, value = p })
                .ToDictionary(
                    p => p.k,
                    p => p.value.Select(
                        x => new MVCproject.Models.ManagerMVC
                        { Id = x.Id, Name = x.ManagerName }));
            //var newManager = managerRepository.GetEntity(new DAL.Models.Manager() { ManagerName = manager });
            //if (newManager != null)
            //{
            // var dataM = new SaleInfoRepository().Items.Select(x => x);

            //Modell.Manager _managerName = new Manager();
            //Modell.SaleInfo _saleInfo = new SaleInfo();
            //Modell.Product _product = new Product();
            //Modell.Client _client = new Client();

            //foreach (var saleInfo in dataM)
            //{
            //    var newDate = saleInfo.Dato;
            //    var  managerName = new ManagerRepository().GetEntityNameById(saleInfo.ID_Manager.Value);
            //    var clientName = new ClientRepository().GetEntityNameById(saleInfo.ID_Client.Value);
            //    var newProduct = new ProductRepository().GetEntityNameById(saleInfo.ID_Product.Value);
            //    var productSum = new SaleInfoRepository().GetEntityNameById(saleInfo.Id);



            //    saleRowsModel.ListRow.Add(new SaleRowModel()
            //    {
            //        ManagerName = managerName.ManagerName,
            //        Date = newDate,
            //        ClientName = clientName.ClientName,
            //        ProductName = newProduct.ProductName,
            //        ProductSum = productSum.Sum
            //    });
            //}


            return View(sales);
        }



        //// GET: Admin/Manager
       
        //public ActionResult Index()
        //{
        //    return View();
        //}

        // GET: Admin/Manager/Details/5
        [AjaxOnly]
        [HttpGet]
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
        [HttpGet]
        [AjaxOnly]
        public ActionResult Create()
        {
            return PartialView();
        }

        // POST: Admin/Manager/Create
        [AjaxOnly]
        [HttpPost]
        public ActionResult Create([Bind(Include = "Id,ManagerName")] Manager manager)
        {
            if (ModelState.IsValid)
            {
                var item = new Modell.Manager() { Id = manager.Id, ManagerName = manager.ManagerName };
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
