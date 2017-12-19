using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCproject.Areas.Default.Controllers
{
    public class UserController : DefaultController
    {
        // GET: Default/User
        public ActionResult Index()
        {
            var users = Repository.Users.ToList();
            return View(users);
        }
    }
}