using IProjenFramework.Business.Abstract;
using IProjenFramework.Business.ValidationRules.FluentValidation;
using IProjenFramework.Core.Aspects.Postsharp.CacheAspect;
using IProjenFramework.Core.Aspects.Postsharp.LogAspect;
using IProjenFramework.Core.Aspects.Postsharp.ValidationAspect;
using IProjenFramework.Core.CrossCuttingConcerns.Caching.Microsoft;
using IProjenFramework.Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using IProjenFramework.DataAccess.Abstract;
using IProjenFramework.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IProjenFramework.Business.Concrete
{
    public class DepartmentManager : IDepartmentService
    {
        private readonly IDepartmentDal _departmentDal;
        public DepartmentManager(IDepartmentDal departmentDal)
        {
            _departmentDal = departmentDal;
        }

        [FluentValidationAspect(typeof(DepartmentValidator))]
        [LogAspect(typeof(DatabaseLogger))]
        public void AddDepartment(Department department)
        {
            _departmentDal.Add(department);
        }

        [FluentValidationAspect(typeof(DepartmentValidator))]
        [LogAspect(typeof(DatabaseLogger))]
        public void UpdateDepartment(Department department)
        {
            _departmentDal.Update(department);
        }

        [LogAspect(typeof(DatabaseLogger))]
        public void DeleteDepartment(Department department)
        {
            _departmentDal.Delete(department);
        }
        public List<Department> GetAllDepartments(Expression<Func<Department, bool>> filter = null,
            Func<IQueryable<Department>, IOrderedQueryable<Department>> orderby = null, int skip = 10, int take = 10)
        {
            return _departmentDal.GetList(filter ?? (k => true),orderby ?? (m => m.OrderByDescending(k => k.Id)),skip,take);
        }
      
        public Department GetDepartmentById(int Id)
        {
            return _departmentDal.Get(k => k.Id == Id);
        }

        public int GetDepartmentCount(Expression<Func<Department, bool>> filter = null)
        {
            return _departmentDal.Count(filter);
        }
    }
}
