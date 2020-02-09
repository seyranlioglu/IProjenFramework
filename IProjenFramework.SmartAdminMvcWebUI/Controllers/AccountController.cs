using IProjenFramework.Business.Abstract;
using IProjenFramework.Core.CrossCuttingConcerns.Security.Web;
using IProjenFramework.Entities.Concrete;
using IProjenFramework.MvcWebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace IProjenFramework.MvcWebUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;
        private readonly IFormUserRightsService _formuserrightService;
        public AccountController(IUserService userService, IFormUserRightsService formuserrightService)
        {
            _userService = userService;
            _formuserrightService = formuserrightService;
        }
        public ActionResult Login()
        {
            LoginViewModel model = new LoginViewModel();
            return View(model);
        }
        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            var user = _userService.GetByUserNameOrEmailAndPassword(model.User.EmailAddress, model.User.Password);
            if (user != null)
            {
               var userrights = _formuserrightService.GetAllUserFormUserRights(user.Id);
               AuthenticationHelper.CreateAuthCookie(
               new Guid(), user.UserName,
               user.EmailAddress,
               DateTime.Now.AddDays(15),
               new string[] { "Index" },
               false,
               user.Name,
               user.Surname,
               userrights.Select(k => k.FormName).ToArray(),
               user.Id,
               userrights.Select(k => k.Id.ToString()).ToArray()
               );
               return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Login", "Account");
        }

        public ActionResult Logout(string r)
        {
            string[] myCookies = Request.Cookies.AllKeys;
            foreach (string cookie in myCookies)
            {
                Response.Cookies[cookie].Expires = DateTime.Now.AddDays(-1);
            }
            FormsAuthentication.SignOut();
            Response.Redirect("/Account/Login?redirectUrl=" + r);
            return Json("");
        }
    }
}