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
    public class UserPositionController : AdminController
    {
        private readonly IUserPositionService _userpositionService;
        public UserPositionController(IUserPositionService userPositionService)
        {
            _userpositionService = userPositionService;
        }

        public ActionResult UserPositionListByPositionId(int Id, JqGridAjaxPostModel jqGridAjax)
        {
            var userpositionList = _userpositionService.GetAllUserPositions(k => k.PositionId == Id);
            var result = from a in userpositionList.Take(jqGridAjax.page * jqGridAjax.rows)
                .Skip((jqGridAjax.page - 1) * jqGridAjax.rows).OrderByDescending(k => k.Id).ToList()
                         select new[] {
                             a.Id.ToString(),
                             a.PositionName,
                             a.UserName,
                             a.PositionId.ToString(),
                             a.UserId.ToString(),
                             a.Id.ToString(),
                         };
            return Json(new
            {
                total = userpositionList.Count == 0 ? 0 :
                            (int)Math.Ceiling((decimal)userpositionList.Count / jqGridAjax.rows),
                jqGridAjax.page,
                records = userpositionList.Count(),
                rows = result
            }, JsonRequestBehavior.AllowGet);
        }

        public void AddOrUpdateUserPositionAjax(UserPosition userposition)
        {
            if (userposition.Id == 0)
                _userpositionService.AddUserPosition(userposition);
            else
                _userpositionService.UpdateUserPosition(userposition);
        }

        [HttpPost]
        public JsonResult DeleteUserPosition(int Id)
        {
            try
            {
                _userpositionService.DeleteUserPosition(_userpositionService.GetUserPositionById(Id));
                return JsonResultExtensions.returnMaxJsonResult("");
            }
            catch (Exception exception)
            {
                return JsonResultExtensions.returnMaxJsonResult("Hata Oluştu.. " + exception.Message);
            }
        }
    }
}