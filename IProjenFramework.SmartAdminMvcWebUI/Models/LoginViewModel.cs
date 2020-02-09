using IProjenFramework.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IProjenFramework.MvcWebUI.Models
{
    public class LoginViewModel
    {
        public User User { get; set; }
        public bool Rememberme { get; set; }
    }
}