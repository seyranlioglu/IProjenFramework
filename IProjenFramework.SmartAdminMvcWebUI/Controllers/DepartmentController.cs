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
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace IProjenFramework.MvcWebUI.Controllers
{
    public class DepartmentController : AdminController
    {
        private readonly IDepartmentService _departmentService;

        private readonly IDataTableSearch<Department> _datatableSearch;
        private readonly IDataTableOrder<Department> _datatableOrder;
        public DepartmentController(IDepartmentService departmentService,
            IDataTableOrder<Department> datatableOrder,
            IDataTableSearch<Department> datatableSearch)
        {
            _departmentService = departmentService;
            _datatableSearch = datatableSearch;
            _datatableOrder = datatableOrder;
        }
        public ActionResult DepartmentList(int formid)
        {
            DepartmentListViewModel model = new DepartmentListViewModel
            {
                FormId = formid
            };
            return View(model);
        }
        [HttpPost]
        public ActionResult DepartmentListDataTable(DataTableAjaxPostModel model)
        {
            var expression = _datatableSearch.CreateSearchExpression(model);
            
            var departmentlist = _departmentService.GetAllDepartments(
                expression,
                _datatableOrder.CreateOrderExpression(model), 
                model.start, 
                model.length + model.start);

            var result = from a in departmentlist
                         select new[] {
                             a.Id.ToString(),
                             a.Id.ToString(),
                             a.Name,
                             a.Description,
                             a.CreateDate != null ? Convert.ToDateTime(a.CreateDate).ToString("dd.MM.yyyy") : ""
                         };
            return Json(new
            {
                Draw = model.draw,
                recordsTotal = _departmentService.GetDepartmentCount(),
                recordsFiltered = _departmentService.GetDepartmentCount(expression),
                data = result
            }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Department(int Id = 0, int formId = 0)
        {
            DepartmentViewModel model = new DepartmentViewModel();
            if (Id > 0)
            {
                model.Department = _departmentService.GetDepartmentById(Id);
            }
            else
            {
                model.Department = new Department
                {
                    Id = 0,
                    Name = "",
                    Description = "",
                    CreateDate = Convert.ToDateTime(DateTime.Now.ToShortDateString())
                };
            }
            ViewBag.FormID = formId;
            return View(model);
        }

        [HttpPost]
        [ValidationHandler]
        public ActionResult AddOrUpdateDepartment(int formId,Department department)
        {
            if (department.Id == 0)
                _departmentService.AddDepartment(department);
            else
                _departmentService.UpdateDepartment(department);
            return RedirectToAction("Browse","Form", new { formId, department.Id });
        }
        public JsonResult DeleteDepartment(int Id)
        {
            try
            {
                _departmentService.DeleteDepartment(_departmentService.GetDepartmentById(Id));
                return JsonResultExtensions.returnMaxJsonResult("");
            }
            catch(Exception exception)
            {
                return JsonResultExtensions.returnMaxJsonResult("Hata Oluştu.. " + exception.Message);
            }
        }

        public JsonResult GetDepartments(string searchTerm, int pageSize = 0, int pageNum = 0)
        {
            List<Department> departments;
            if (searchTerm == null)
                departments = _departmentService.GetAllDepartments(take: pageSize, skip: (pageNum * pageSize) - 100);
            else
                departments = _departmentService.GetAllDepartments(k => k.Name.Contains(searchTerm) || k.Description.Contains(searchTerm), take: pageSize, skip: (pageNum * pageSize) - 100);

            var result = new
            {
                Total = departments.Count(),
                Results = Select2ModelConst<Department, DepartmentMap>.Select2ModelComponent(departments)
            };

            return new JsonResult
            {
                Data = result,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
    }
}