using IProjenFramework.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IProjenFramework.Business.Abstract
{
    public interface IFormService
    {
        List<Form> GetAllFormsByFormIdList(List<int> formIds);
        Form GetFormById(int formid);
        List<Form> GetAllForms(Expression<Func<Form, bool>> filter = null, Func<IQueryable<Form>, IOrderedQueryable<Form>> orderBy = null, int skip = 0, int take = 0);
    }
}
