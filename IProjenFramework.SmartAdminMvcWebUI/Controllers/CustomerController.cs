using IProjenFramework.Business.Abstract;
using IProjenFramework.Core.Utilities.Mvc;
using IProjenFramework.Entities.Concrete;
using IProjenFramework.MvcWebUI.App_Helper;
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
    public class CustomerController : AdminController
    {
        private readonly ICustomerService _customerService;
        private readonly IDataTableSearch<Customer> _datatableSearch;
        private readonly IDataTableOrder<Customer> _datatableOrder;

        public CustomerController(ICustomerService customerService,
            IDataTableOrder<Customer> datatableOrder,
            IDataTableSearch<Customer> datatableSearch)
        {
            _customerService = customerService;
            _datatableSearch = datatableSearch;
            _datatableOrder = datatableOrder;
        }


        public ActionResult CustomerList(int formid)
        {
            CustomerListViewModel model = new CustomerListViewModel
            {
                FormId = formid
            };
            return View(model);
        }


        [HttpPost]
        public ActionResult CustomerListDataTable(DataTableAjaxPostModel model)
        {
            var expression = _datatableSearch.CreateSearchExpression(model);

            var customerList = _customerService.GetAllCustomers(
                expression,
                _datatableOrder.CreateOrderExpression(model),
                model.start,
                model.length + model.start);

            var result = from a in customerList
                         select new[] {
                             a.Id.ToString(),
                             a.Id.ToString(),
                             a.DisplayName,
                             a.CommercialTitle,
                             a.TaxOffice,
                             a.TaxNumber,
                             a.Identifier,
                             a.TelephoneNumber,
                             a.EmailAddress,
                             a.WebAddress
                         };
            return Json(new
            {
                Draw = model.draw,
                recordsTotal = _customerService.GetCustomerCount(),
                recordsFiltered = _customerService.GetCustomerCount(expression),
                data = result
            }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Customer(int Id = 0, int formId = 0)
        {
            CustomerViewModel model = new CustomerViewModel();
            if (Id > 0)
            {
                model.Customer = _customerService.GetDepartmentById(Id);
            }
            else
            {
                model.Customer = new Customer
                {
                    Id = 0,
                    CommercialTitle = "",
                    DisplayName = "",
                    EmailAddress = "",
                    Identifier = "",
                    TaxNumber = "",
                    TaxOffice = "",
                    TelephoneNumber = "",
                    WebAddress = ""
                };
            }
            ViewBag.FormID = formId;
            return View(model);
        }

        [HttpPost]
        [ValidationHandler]
        public ActionResult AddOrUpdateCustomer(int formId, Customer customer)
        {
            if (customer.Id == 0)
                _customerService.AddCustomer(customer);
            else
                _customerService.UpdateCustomer(customer);
            return RedirectToAction("Browse", "Form", new { formId, customer.Id });
        }
    }
}