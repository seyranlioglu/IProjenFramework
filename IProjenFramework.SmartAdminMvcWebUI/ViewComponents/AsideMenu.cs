using IProjenFramework.Business.Abstract;
using IProjenFramework.MvcWebUI.ExtensionMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace IProjenFramework.MvcWebUI.ViewComponents
{
    public class AsideMenu
    {
        private readonly IFormUserRightsService _formuserrightService;
        private readonly IFormService _formService;
        
        public AsideMenu(IFormUserRightsService formUserRightsService, IFormService formService)
        {
            _formuserrightService = formUserRightsService;
            _formService = formService;
        }
        public string CreateAsideMenuTag()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("<ul>");
            builder.Append(GetFormsNoDesignGroup());
            builder.Append("</ul>");
            return "";
        }
        public StringBuilder GetFormsNoDesignGroup()
        {
            var forms = _formService.GetAllFormsByFormIdList(UserIdentityInfo.FormIds);
            StringBuilder builder = new StringBuilder();
            foreach (var item in forms)
            {
                builder.Append("<li class='active'>");
                builder.Append(@"<a href = 'calendar/home')><i class='fa fa - lg fa - fw fa - calendar'><em>3</em></i> <span class='menu - item - parent'>Calendar</span></a>");
                builder.Append("</li>");
            }
            return builder;
        }

         //<li class="@Html.RouteIf("calendar", "active")">
         //       <a href = "@Url.Action("calendar", "home")"><i class="fa fa-lg fa-fw fa-calendar"><em>3</em></i> <span class="menu-item-parent">Calendar</span></a>
         //   </li>
    }
}