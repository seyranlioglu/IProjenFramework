using AutoMapper;
using IProjenFramework.Business.Abstract;
using IProjenFramework.Core.Utilities.Mvc;
using IProjenFramework.Entities.Concrete;
using IProjenFramework.MvcWebUI.Components.Select2Component;
using IProjenFramework.MvcWebUI.Filters;
using IProjenFramework.MvcWebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IProjenFramework.MvcWebUI.Controllers
{
    [HandleException]
    public class FormController : AdminController
    {
        private readonly IFormService _formService;
        public FormController(IFormService formService)
        {
            _formService = formService;
        }
        public ActionResult List(int formid)
        {
            var forms = _formService.GetFormById(formid);
            FormListViewModel model = new FormListViewModel
            {
                FormId = formid,
                ActionName = forms.Action,
                ControllerName = forms.Controller,
                Description = forms.Description
            };
            return View(model);
        }
        public ActionResult Browse(int formid,int Id)
        {
            var forms = _formService.GetFormById(formid);
            FormViewModel model = new FormViewModel
            {
                FormId = formid,
                FormName = forms.Name,
                ActionName = forms.Action,
                ControllerName = forms.Controller,
                RecordId = Id
            };
            return View(model);
        }

        public ActionResult New(int formid)
        {
            var forms = _formService.GetFormById(formid);
            FormViewModel model = new FormViewModel
            {
                FormId = formid,
                FormName = forms.Name,
                ActionName = forms.Action,
                ControllerName = forms.Controller,
            };
            return View(model);
        }

        public JsonResult GetAllForms(int Id, string searchTerm, int pageSize = 0, int pageNum = 0)
        {
            List<Form> forms;
            if (searchTerm == null)
                forms = _formService.GetAllForms(k => k.Id != Id, take: pageSize, skip: (pageNum * pageSize) - 100);
            else
                forms = _formService.GetAllForms(k => k.Name.Contains(searchTerm), take: pageSize, skip: (pageNum * pageSize) - 100);

            var result = new
            {
                Total = forms.Count(),
                Results = Select2ModelConst<Form,FormMap>.Select2ModelComponent(forms)
            };

            return new JsonResult
            {
                Data = result,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
    }
}