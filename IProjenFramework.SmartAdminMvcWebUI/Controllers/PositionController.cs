using IProjenFramework.Business.Abstract;
using IProjenFramework.Entities.ComplexType;
using IProjenFramework.Entities.Concrete;
using IProjenFramework.MvcWebUI.App_Helper;
using IProjenFramework.MvcWebUI.ExtensionMethods;
using IProjenFramework.MvcWebUI.Filters;
using IProjenFramework.MvcWebUI.Models;
using IProjenFramework.MvcWebUI.SearchableModels.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace IProjenFramework.MvcWebUI.Controllers
{
    public class PositionController : Controller
    {
        private readonly IPositionService _positionService;
        private readonly IDataTableSearch<PositionView> _datatableSearch;
        private readonly IDataTableOrder<PositionView> _datatableOrder;
        private readonly IDepartmentService _departmentService;
        public PositionController(
            IPositionService positionService, 
            IDataTableOrder<PositionView> datatableOrder,
            IDataTableSearch<PositionView> datatableSearch,
            IDepartmentService departmentService)
        {
            _positionService = positionService;
            _datatableSearch = datatableSearch;
            _datatableOrder = datatableOrder;
            _departmentService = departmentService;
        }
        public ActionResult PositionList(int formid)
        {
            PositionListViewModel model = new PositionListViewModel
            {
                FormId = formid
            };
            return View(model);
        }

        public ActionResult PositionListDataTable(DataTableAjaxPostModel model)
        {
            var expression = _datatableSearch.CreateSearchExpression(model);

            var positionList = _positionService.GetAllPositions(
                expression,
                _datatableOrder.CreateOrderExpression(model),
                model.start,
                model.length + model.start);

            var result = from a in positionList
                         select new[] {
                             a.Id.ToString(),
                             a.Id.ToString(),
                             a.Name,
                             a.Description,
                             a.DepartmentName
                         };
            return Json(new
            {
                Draw = model.draw,
                recordsTotal = _positionService.GetPositionViewCount(),
                recordsFiltered = _positionService.GetPositionViewCount(expression),
                data = result
            }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Position(int Id = 0, int formId = 0)
        {
            PositionViewModel model = new PositionViewModel();
            if (Id > 0)
            {
                model.Position = _positionService.GetPositionById(Id);
                model.Departments = _departmentService.GetAllDepartments(k => k.Id != model.Position.DepartmentId,take: 10, skip: 0);
                model.Departments.Add(_departmentService.GetDepartmentById((int)model.Position.DepartmentId));
            }
            else
            {
                model.Position = new Position
                {
                    Id = 0,
                    Name = "",
                    Description = "",
                    DepartmentId = 0,
                };
                model.Departments = _departmentService.GetAllDepartments(take: 10, skip: 0);
            }
            ViewBag.FormID = formId;
            return View(model);
        }
        public ActionResult PositionListByDepartment(int Id, JqGridAjaxPostModel jqGridAjax)
        {
            var positionList = _positionService.GetAllPositionsByDepartmentId(Id);
            var result = from a in positionList.Take(jqGridAjax.page * jqGridAjax.rows)
                .Skip((jqGridAjax.page - 1) * jqGridAjax.rows).OrderByDescending(k => k.Id).ToList()
                         select new[] {
                             a.Id.ToString(),
                             a.Name,
                             a.Description,
                             a.DepartmentId.ToString(),
                             a.Id.ToString(),
                         };
            return Json(new
            {
                total = positionList.Count == 0 ? 0 :
                            (int)Math.Ceiling((decimal)positionList.Count / jqGridAjax.rows),
                jqGridAjax.page,
                records = _positionService.GetPositionViewCount(),
                rows = result
            }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Departman formunda detay ekleme için
        /// </summary>
        /// <param name="position"></param>
        public void AddOrUpdatePositionAjax(Position position)
        {
            if (position.Id == 0)
                _positionService.AddPosition(position);
            else
                _positionService.UpdatePosition(position);
        }

        /// <summary>
        /// Pozisyon formu post
        /// </summary>
        /// <param name="formId"></param>
        /// <param name="position"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidationHandler]
        public ActionResult AddOrUpdatePosition(int formId, Position position)
        {
            if (position.Id == 0)
                _positionService.AddPosition(position);
            else
                _positionService.UpdatePosition(position);
            return RedirectToAction("Browse", "Form", new { formId, position.Id });
        }

        [HttpPost]
        public JsonResult DeletePosition(int Id)
        {
            try
            {
                _positionService.DeletePosition(_positionService.GetPositionById(Id));
                return JsonResultExtensions.returnMaxJsonResult("");
            }
            catch (Exception exception)
            {
                return JsonResultExtensions.returnMaxJsonResult("Hata Oluştu.. " + exception.Message);
            }
        }
    }
}