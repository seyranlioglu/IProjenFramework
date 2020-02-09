using IProjenFramework.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IProjenFramework.Business.Abstract
{
    public interface IDepartmentService
    {
        void AddDepartment(Department department);
        void UpdateDepartment(Department department);
        void DeleteDepartment(Department department);
        List<Department> GetAllDepartments(Expression<Func<Department, bool>> filter = null,
            Func<IQueryable<Department>, IOrderedQueryable<Department>> orderby = null, int skip = 0, int take = 0);
        Department GetDepartmentById(int Id);
        int GetDepartmentCount(Expression<Func<Department, bool>> filter = null);
    }
}
