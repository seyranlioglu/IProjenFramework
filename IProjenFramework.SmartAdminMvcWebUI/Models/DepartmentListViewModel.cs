using IProjenFramework.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IProjenFramework.MvcWebUI.Models
{
    public class DepartmentListViewModel
    {
        public List<Department> Department { get; set; }
        public int FormId { get; set; }
    }
}