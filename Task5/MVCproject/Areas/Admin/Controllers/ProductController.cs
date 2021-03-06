﻿using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DAL;

using MVCproject.Controllers;
using MVCproject.Models;

namespace MVCproject.Areas.Admin.Controllers
{
    public class ProductController : BaseController
    {
        // GET: Products
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

        // GET: Products/Details/5
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

        // GET: Products/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] Models.ProductMVC product)
        {

            if (ModelState.IsValid)
            {
                var item = new Modell.Product() { Id = product.Id, ProductName = product.Name };
                new DAL.Repository.ProductRepository()
                    .Insert(item);
                return RedirectToAction("Index");
            }

            return View(product);
        }

        // GET: Products/Edit/5
    
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var productId = id ?? default(int);

            var product = new DAL.Repository.ProductRepository()
                .GetById(productId).Select(x => new Models.ProductMVC() { Id = x.Id, Name = x.ProductName })
                .FirstOrDefault();

            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
       
     
        public ActionResult Edit([Bind(Include = "Id,Name")] Models.ProductMVC product)
        {
           
            if (ModelState.IsValid)
            {
                var item = new DAL.Repository.ProductRepository()
                    .GetById(product.Id)
                    .FirstOrDefault();

                if (item != null)
                {
                    item.ProductName = product.Name;
                    new DAL.Repository.ProductRepository()
                        .Update(item);

                    return RedirectToAction("Index");
                }
            }
            return View(product);
        }

        // GET: Products/Delete/5

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var productId = id ?? default(int);

            var product = new DAL.Repository.ProductRepository()
                .GetById(productId)
                .Select(m => new Models.ProductMVC() { Id = m.Id, Name = m.ProductName })
                .FirstOrDefault();

            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var product = new DAL.Repository.ProductRepository()
                .GetById(id)
                .FirstOrDefault();

            new DAL.Repository.ProductRepository()
                .Remove(product);

            return RedirectToAction("Index");
        }

    }
}
    

