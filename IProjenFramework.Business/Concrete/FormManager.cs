using IProjenFramework.Business.Abstract;
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
    public class FormManager : IFormService
    {
        private readonly IFormDal _formDal;
        public FormManager(IFormDal formDal)
        {
            _formDal = formDal;
        }

        public List<Form> GetAllForms(Expression<Func<Form, bool>> filter = null, Func<IQueryable<Form>, IOrderedQueryable<Form>> orderBy = null, int skip = 0, int take = 0)
        {
            return _formDal.GetList(filter ?? (x => true), orderBy ?? (m => m.OrderByDescending(k => k.Id)), skip, take);
        }

        public List<Form> GetAllFormsByFormIdList(List<int> formIds)
        {
            return _formDal.GetList(k => formIds.Contains(k.Id));
        }

        public Form GetFormById(int formid)
        {
            return _formDal.Get(k => k.Id == formid);
        }
    }
}
