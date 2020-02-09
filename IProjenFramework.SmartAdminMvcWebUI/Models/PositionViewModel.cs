using IProjenFramework.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IProjenFramework.MvcWebUI.Models
{
    public class PositionViewModel
    {
        public Position Position { get; set; }
        public List<Department> Departments { get; set; }
    }
}