using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IProjenFramework.MvcWebUI.Models
{
    public class FormViewModel
    {
        public int FormId { get; set; }
        public int RecordId { get; set; }
        public string FormName { get; set; }
        public string ActionName { get; set; }
        public string ControllerName { get; set; }
    }
}