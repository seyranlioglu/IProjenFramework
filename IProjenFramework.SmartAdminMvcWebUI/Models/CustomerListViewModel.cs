using IProjenFramework.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IProjenFramework.MvcWebUI.Models
{
    public class CustomerListViewModel
    {
        public List<Customer> Customers { get; set; }
        public int FormId { get; set; }
    }
}