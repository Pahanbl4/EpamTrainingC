using MVCproject.Controllers;
using MVCproject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCproject.Areas.Admin.Controllers
{
    public class StatisticsController : BaseController
    {
        // GET: Admin/Statistics
        public ActionResult Index()
        {
            return View();
        }

        [AjaxOnly]
        public JsonResult GetChartData(int? id)
        {
            if (id == null)
            {
                var items = new DAL.Repository.ManagerRepository()
                    .GetAll()
                    .Select(d => new object[]
                    {
                        d.ManagerName,
                        new DAL.Repository.ManagerRepository()
                        .GetSumById(d.Id)
                    })
                    .ToArray();

                return Json(items, JsonRequestBehavior.AllowGet);
            }

            int idManager = id ?? default(int);

            var sales = new DAL.Repository.ManagerRepository()
                .GetSalesByManagerId(idManager)
                .OrderBy(x => x.Dato)
                .GroupBy(x => x.Dato.Date)
                .Select(d => new object[] { d.Key, d.Sum(s => s.Sum) })
                .ToArray();

            return Json(sales, JsonRequestBehavior.AllowGet);
        }

    }
}