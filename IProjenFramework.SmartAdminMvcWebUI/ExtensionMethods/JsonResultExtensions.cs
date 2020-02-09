using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IProjenFramework.MvcWebUI.ExtensionMethods
{
    public static class JsonResultExtensions
    {
        public static JsonResult returnMaxJsonResult(object inReturnValue)
        {
            return new JsonResult()
            {
                Data = inReturnValue,
                ContentType = "application/json",
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                MaxJsonLength = Int32.MaxValue
            };
        }
    }
}