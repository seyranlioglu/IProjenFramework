using IProjenFramework.Business.Abstract;
using IProjenFramework.Core.Aspects.Postsharp.LogAspect;
using IProjenFramework.Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using IProjenFramework.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationTest.DbContext;

namespace WebApplicationTest.Controllers
{
    
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _departmentService;
        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }
        //public ActionResult Department(int departmentId)
        //{
        //    using(var db = new IProjenFrameworkDBEntities())
        //    {
        //        UpdateDepartment(db.Departments.Where(k => k.Id == departmentId).FirstOrDefault());
        //        return View(db.Departments.Where(k => k.Id == departmentId).ToList());
        //    }
        //}

        //public string UpdateDepartment(Departments departments)
        //{
        //    departments.CreateDate = DateTime.Now;
        //    using (var db = new IProjenFrameworkDBEntities())
        //    {
        //        var updatedEntity = db.Entry(departments);
        //        updatedEntity.State = EntityState.Modified;
        //        db.SaveChanges();
        //    }
        //    return "Eklendi";
        //}

        public ActionResult Department(int departmentId)
        {
            Department department = _departmentService.GetDepartmentById(departmentId);
            UpdateDepartment(department);
            return View(department);
        }

        public string UpdateDepartment(Department department)
        {
            department.CreateDate = DateTime.Now;
            _departmentService.UpdateDepartment(department);
            return "Eklendi";
        }
    }
}