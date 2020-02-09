using IProjenFramework.Business.Abstract;
using IProjenFramework.Business.ValidationRules.FluentValidation;
using IProjenFramework.Core.Aspects.Postsharp.LogAspect;
using IProjenFramework.Core.Aspects.Postsharp.ValidationAspect;
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
    public class CustomerManager : ICustomerService
    {
        private readonly ICustomerDal _customerDal;
        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        [FluentValidationAspect(typeof(CustomerValidator))]
        [LogAspect(typeof(DatabaseLogger))]
        public void AddCustomer(Customer customer)
        {
            _customerDal.Add(customer);
        }

        [FluentValidationAspect(typeof(CustomerValidator))]
        [LogAspect(typeof(DatabaseLogger))]
        public void UpdateCustomer(Customer customer)
        {
            _customerDal.Update(customer);
        }

        public void DeleteCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }

        public List<Customer> GetAllCustomers(Expression<Func<Customer, bool>> filter = null, Func<IQueryable<Customer>, IOrderedQueryable<Customer>> orderby = null, int skip = 0, int take = 0)
        {
            return _customerDal.GetList(filter ?? (k => true), orderby ?? (m => m.OrderByDescending(k => k.Id)), skip, take);
        }

        public int GetCustomerCount(Expression<Func<Customer, bool>> filter = null)
        {
            return _customerDal.Count(filter);
        }

        public Customer GetDepartmentById(int Id)
        {
            return _customerDal.Get(k => k.Id == Id);
        }

    }
}
