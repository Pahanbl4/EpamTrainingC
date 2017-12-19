using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCproject.Areas.Default.Controllers
{
    public class HomeController : DefaultController
    {
        // GET: Default/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}