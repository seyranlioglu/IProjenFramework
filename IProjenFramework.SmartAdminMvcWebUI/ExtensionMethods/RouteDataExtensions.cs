using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace IProjenFramework.MvcWebUI.ExtensionMethods
{
    public class RouteDataExtensions
    {
        public static string GetRouteDataList()
        {
            var route = HttpContext.Current.Request.RequestContext.RouteData;
            return  route.Values["formid"].ToString();
        }
    }
}