using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Routing;

namespace IProjenFramework.Core.Utilities.Mvc
{
    public class AdminController : Controller
    {
        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);
            if (!User.Identity.IsAuthenticated)
            {
                var c = requestContext.RouteData.Values["controller"];
                var a = requestContext.RouteData.Values["action"];
                requestContext.RouteData.Values["controller"] = "Account";
                requestContext.RouteData.Values["action"] = "Logout";
                Response.Redirect("/Account/logout?r=/" + c + "/" + a);
            }
        }
    }
}
