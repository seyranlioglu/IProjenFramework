using IProjenFramework.Core.CrossCuttingConcerns.Security;
using IProjenFramework.Core.Utilities.Mvc;
using IProjenFramework.MvcWebUI.ExtensionMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace IProjenFramework.MvcWebUI.Controllers
{
    public class HomeController : AdminController
    {
        public ActionResult Index()
        {
            return View();
        }
        
    }
}