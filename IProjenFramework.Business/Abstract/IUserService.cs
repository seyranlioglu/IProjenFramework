using IProjenFramework.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IProjenFramework.Business.Abstract
{
    public interface IUserService
    {
        User GetByUserNameOrEmailAndPassword(string useremail, string password);
        void AddUser(User user);
        void UpdateUser(User user);
        void DeleteUser(int userid);
        User GetUserById(int userid);
        List<User> GetAllUsers(Expression<Func<User, bool>> filter = null,
            Func<IQueryable<User>, IOrderedQueryable<User>> orderby = null, int skip = 0, int take = 10);
        bool UserIsAdmin(User user);
        int UserCount(Expression<Func<User, bool>> filter = null);
        bool IsUserAndPassword(string usermail, string password);
    }
}
