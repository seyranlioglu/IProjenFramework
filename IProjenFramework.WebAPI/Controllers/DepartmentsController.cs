using IProjenFramework.Business.Abstract;
using IProjenFramework.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace IProjenFramework.WebAPI.Controllers
{
    [Authorize]
    public class DepartmentsController : ApiController
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentsController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }
        public HttpResponseMessage GetDepartments(int? Id = null)
        {
            try
            {
                var departments = _departmentService.GetAllDepartments(filter: k => k.Id == (Id == null ? k.Id : Id), take: 10, skip: 0);
                return Request.CreateResponse(HttpStatusCode.OK, departments);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }

        }
    }
}
