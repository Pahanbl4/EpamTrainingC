using DAL.Repository;
using Modell;
using MVCproject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MVCproject.Areas.Default.Controllers
{
    public class SaleInfoController : DefaultController
    {

        public ActionResult Index()
        {
            var products = new DAL.Repository.ProductRepository()
               .GetAll()
               .GroupBy(p => p.ProductName.Substring(0, 1))
               .Select(p => new { k = p.Key, value = p })
               .ToDictionary(
                   p => p.k,
                   p => p.value.Select(
                       x => new Models.ProductMVC()
                       { Id = x.Id, Name = x.ProductName }));
            return View(products);
        }

        // GET: Admin/Product/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var productId = id ?? default(int);

            var product = new DAL.Repository.ProductRepository()
                .GetById(productId)
                .Select(y => new Models.ProductMVC() { Id = y.Id, Name = y.ProductName })
                .FirstOrDefault();

            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Admin/Product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Product/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "Id,Name")] Models.ProductMVC product)
        {
            if (ModelState.IsValid)
            {
                var item = new Product() { Id = product.Id, ProductName = product.Name };
                new DAL.Repository.ProductRepository()
                    .Insert(item);
                return RedirectToAction("Index");
            }

            return View(product);
        }

    }
}