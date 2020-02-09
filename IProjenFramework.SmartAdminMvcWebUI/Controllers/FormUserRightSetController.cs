using IProjenFramework.Business.Abstract;
using IProjenFramework.Core.Utilities.Mvc;
using IProjenFramework.Entities.Concrete;
using IProjenFramework.MvcWebUI.App_Helper;
using IProjenFramework.MvcWebUI.ExtensionMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IProjenFramework.MvcWebUI.Controllers
{
    public class FormUserRightSetController : AdminController
    {
        private readonly IFormUserRightsService _formUserRightSetService;
        public FormUserRightSetController(IFormUserRightsService formUserRightsService)
        {
            _formUserRightSetService = formUserRightsService;
        }
        public ActionResult FormUserRightSetList()
        {
            return View();
        }
        
        /// <summary>
        /// Departman Tanımları formunda kullanılıyor.
        /// </summary>
        /// <returns></returns>
        public ActionResult FormUserRightSetByDepartment(int Id, JqGridAjaxPostModel jqGridAjax)
        {
            var userrightlist = _formUserRightSetService.GetAllFormUserRightsByDepartmentId(Id);
            var result = from a in userrightlist.Take(jqGridAjax.page * jqGridAjax.rows)
                .Skip((jqGridAjax.page - 1) * jqGridAjax.rows).OrderByDescending(k => k.Id).ToList()
                         select new[] {
                             a.Id.ToString(),
                             a.FormId.ToString(),
                             a.FormName,
                             a.ViewRight == true ? "Var" : "Yok",
                             a.InsertRight == true ? "Var" : "Yok",
                             a.UpdateRight == true ? "Var" : "Yok",
                             a.DeleteRight == true ? "Var" : "Yok",
                             a.UserId.ToString(),
                             a.Id.ToString(),
                         };
            return Json(new
            {
                total = userrightlist.Count == 0 ? 0 :
                            (int)Math.Ceiling((decimal)userrightlist.Count / jqGridAjax.rows),
                jqGridAjax.page,
                records = userrightlist.Count(),
                rows = result
            }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Pozisyon Tanımları formunda kullanılıyor.
        /// </summary>
        /// <returns></returns>
        public ActionResult FormUserRightSetByPosition(int Id, JqGridAjaxPostModel jqGridAjax)
        {
            var userrightlist = _formUserRightSetService.GetAllFormUserRightsByPositionId(Id);
            var result = from a in userrightlist.Take(jqGridAjax.page * jqGridAjax.rows)
                .Skip((jqGridAjax.page - 1) * jqGridAjax.rows).OrderByDescending(k => k.Id).ToList()
                         select new[] {
                             a.Id.ToString(),
                             a.FormId.ToString(),
                             a.FormName,
                             a.ViewRight == true ? "Var" : "Yok",
                             a.InsertRight == true ? "Var" : "Yok",
                             a.UpdateRight == true ? "Var" : "Yok",
                             a.DeleteRight == true ? "Var" : "Yok",
                             a.UserId.ToString(),
                             a.Id.ToString(),
                         };
            return Json(new
            {
                total = userrightlist.Count == 0 ? 0 :
                            (int)Math.Ceiling((decimal)userrightlist.Count / jqGridAjax.rows),
                jqGridAjax.page,
                records = userrightlist.Count(),
                rows = result
            }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Kullanıcı Tanımları formunda kulanılıyor.
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="jqGridAjax"></param>
        /// <returns></returns>
        public ActionResult FormUserRightSetByUser(int Id, JqGridAjaxPostModel jqGridAjax)
        {
            var userrightlist = _formUserRightSetService.GetAllFormUserRightsByUserId(Id);
            var result = from a in userrightlist.Take(jqGridAjax.page * jqGridAjax.rows)
                .Skip((jqGridAjax.page - 1) * jqGridAjax.rows).OrderByDescending(k => k.Id).ToList()
                         select new[] {
                             a.Id.ToString(),
                             a.FormId.ToString(),
                             a.FormName,
                             a.ViewRight == true ? "Var" : "Yok",
                             a.InsertRight == true ? "Var" : "Yok",
                             a.UpdateRight == true ? "Var" : "Yok",
                             a.DeleteRight == true ? "Var" : "Yok",
                             a.UserId.ToString(),
                             a.Id.ToString(),
                         };
            return Json(new
            {
                total = userrightlist.Count == 0 ? 0 :
                            (int)Math.Ceiling((decimal)userrightlist.Count / jqGridAjax.rows),
                jqGridAjax.page,
                records = userrightlist.Count(),
                rows = result
            }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Departman,Pozisyon ve Kullanıcı Tanımlarında kullanılacak.
        /// </summary>
        /// <param name="userRightSet"></param>
        public void AddOrUpdateFormUserRightSet(int UserTypes, FormUserRightSet userRightSet)
        {
            switch (UserTypes)
            {
                case 1:
                    userRightSet.UserType = FormUserRightSet.UserTypes.User;
                    break;
                case 2:
                    userRightSet.UserType = FormUserRightSet.UserTypes.Position;
                    break;
                case 3:
                    userRightSet.UserType = FormUserRightSet.UserTypes.Department;
                    break;
            }
            if (userRightSet.Id == 0)
                _formUserRightSetService.AddFormUserRightSet(userRightSet);
            else
                _formUserRightSetService.UpdateFormUserRightSet(userRightSet);
        }

        [HttpPost]
        public JsonResult DeleteFormUserRightSet(int Id)
        {
            try
            {
                _formUserRightSetService.DeleteFormUserRightSet(Id);
                return JsonResultExtensions.returnMaxJsonResult("");
            }
            catch (Exception exception)
            {
                return JsonResultExtensions.returnMaxJsonResult("Hata Oluştu.. " + exception.Message);
            }
        }
    }
}