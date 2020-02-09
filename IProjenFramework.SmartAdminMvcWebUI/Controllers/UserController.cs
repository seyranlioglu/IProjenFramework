using IProjenFramework.Business.Abstract;
using IProjenFramework.Core.Utilities.Mvc;
using IProjenFramework.Entities.Concrete;
using IProjenFramework.MvcWebUI.App_Helper;
using IProjenFramework.MvcWebUI.Components.Select2Component;
using IProjenFramework.MvcWebUI.ExtensionMethods;
using IProjenFramework.MvcWebUI.Filters;
using IProjenFramework.MvcWebUI.Models;
using IProjenFramework.MvcWebUI.SearchableModels.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IProjenFramework.MvcWebUI.Controllers
{
    public class UserController : AdminController
    {
        private readonly IUserService _userService;
        private readonly IDataTableSearch<User> _datatableSearch;
        private readonly IDataTableOrder<User> _datatableOrder;
        public UserController(
            IUserService userService,
            IDataTableOrder<User> datatableOrder,
            IDataTableSearch<User> datatableSearch)
        {
            _userService = userService;
            _datatableSearch = datatableSearch;
            _datatableOrder = datatableOrder;
        }

        public ActionResult UserList(int formId)
        {
            UserListViewModel model = new UserListViewModel
            {
                FormId = formId
            };
            return View(model);
        }

        public ActionResult UserListDataTable(DataTableAjaxPostModel model)
        {
            var expression = _datatableSearch.CreateSearchExpression(model);

            var userList = _userService.GetAllUsers(
                expression,
                _datatableOrder.CreateOrderExpression(model),
                model.start,
                model.length + model.start);

            var result = from a in userList
                         select new[] {
                             a.Id.ToString(),
                             a.Id.ToString(),
                             a.Name + " " + a.Surname,
                             a.Title,
                             a.EmailAddress,
                             a.IsAdminUser == true ? "Admin" : "Normal"
                         };
            return Json(new
            {
                Draw = model.draw,
                recordsTotal = _userService.UserCount(),
                recordsFiltered = _userService.UserCount(expression),
                data = result
            }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAllUsers(int Id,string searchTerm, int pageSize = 0, int pageNum = 0)
        {
            List<User> users;
            if (searchTerm == null)
                users = _userService.GetAllUsers(k=>k.Id != Id,take: pageSize, skip: (pageNum * pageSize) - 100);
            else
                users = _userService.GetAllUsers(k => k.Name.Contains(searchTerm), take: pageSize, skip: (pageNum * pageSize) - 100);

            var result = new
            {
                Total = users.Count(),
                Results = Select2ModelConst<User, UserMap>.Select2ModelComponent(users)
            };

            return new JsonResult
            {
                Data = result,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }

        public ActionResult User(int Id = 0, int formId = 0)
        {
            UserViewModel model = new UserViewModel();
            if (Id > 0)
            {
                model.User = _userService.GetUserById(Id);
            }
            else
            {
                model.User = new User
                {
                    Id = 0,
                    Name = "",
                    Surname = "",
                    EmailAddress = "",
                    EmailPassword = "",
                    UserName = "",
                    Password = "",
                    Title = "",
                    IsAdminUser = false
                };
            }
            ViewBag.FormID = formId;
            return View(model);
        }

        [HttpPost]
        [ValidationHandler]
        public ActionResult AddOrUpdateUser(int formId, User user)
        {
            if (user.Id == 0)
                _userService.AddUser(user);
            else
                _userService.UpdateUser(user);
            return RedirectToAction("Browse", "Form", new { formId, user.Id });
        }
        public JsonResult DeleteUser(int Id)
        {
            try
            {
                _userService.DeleteUser(Id);
                return JsonResultExtensions.returnMaxJsonResult("");
            }
            catch (Exception exception)
            {
                return JsonResultExtensions.returnMaxJsonResult("Hata Oluştu.. " + exception.Message);
            }
        }
    }
}