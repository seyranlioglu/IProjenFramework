using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IProjenFramework.MvcWebUI.Filters
{
    public class HandleExceptionAttribute : FilterAttribute,IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            var result = new ViewResult { ViewName = "Error" };
            var modelDataProvider = new EmptyModelMetadataProvider();
            result.ViewData = new ViewDataDictionary();
            result.ViewData.Add("HandleException", filterContext.Exception);
            filterContext.Result = result;
            filterContext.ExceptionHandled = true;
        }
    }
}