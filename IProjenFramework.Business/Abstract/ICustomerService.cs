using IProjenFramework.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IProjenFramework.Business.Abstract
{
    public interface ICustomerService
    {
        void AddCustomer(Customer customer);
        void UpdateCustomer(Customer customer);
        void DeleteCustomer(Customer customer);
        List<Customer> GetAllCustomers(Expression<Func<Customer, bool>> filter = null,
            Func<IQueryable<Customer>, IOrderedQueryable<Customer>> orderby = null, int skip = 0, int take = 0);
        Customer GetDepartmentById(int Id);
        int GetCustomerCount(Expression<Func<Customer, bool>> filter = null);
    }
}
