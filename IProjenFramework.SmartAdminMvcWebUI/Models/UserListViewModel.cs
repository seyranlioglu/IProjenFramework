using IProjenFramework.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IProjenFramework.MvcWebUI.Models
{
    public class UserListViewModel
    {
        public List<User> Users { get; set; }
        public int FormId { get; set; }
    }
}