using Modell.UsersModel.Model;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCproject.Controllers
{
    public abstract class BaseController : Controller
    {
        [Inject]
        public IUserRepository Repository { get; set; }

       
    }
}