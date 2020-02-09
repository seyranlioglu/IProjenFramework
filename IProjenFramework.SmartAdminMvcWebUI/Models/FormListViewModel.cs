using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IProjenFramework.MvcWebUI.Models
{
    public class FormListViewModel
    {
        public int FormId { get; set; }
        public string ActionName { get; set; }
        public string ControllerName { get; set; }
        public string Description { get; set; }
        public bool ViewRight { get; set; }
        public bool InsertRight { get; set; }
        public bool UpdateRight { get; set; }
        public bool DeleteRight { get; set; }
    }
}