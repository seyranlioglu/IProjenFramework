using IProjenFramework.Business.Abstract;
using IProjenFramework.Core.Aspects.Postsharp.LogAspect;
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
    public class UserManager : IUserService
    {
        private IUserDal _userdal;
        
        public UserManager(IUserDal userDal)
        {
            _userdal = userDal;
        }

        [LogAspect(typeof(DatabaseLogger))]
        public void AddUser(User user)
        {
            _userdal.Add(user);
        }

        [LogAspect(typeof(DatabaseLogger))]
        public void UpdateUser(User user)
        {
            _userdal.Update(user);
        }

        [LogAspect(typeof(DatabaseLogger))]
        public void DeleteUser(int userid)
        {
            _userdal.Delete(_userdal.Get(k => k.Id == userid));
        }

        public User GetUserById(int userid)
        {
            return _userdal.Get(k => k.Id == userid);
        }

        public User GetByUserNameOrEmailAndPassword(string useremail, string password)
        {
            return _userdal.Get(k => k.EmailAddress == useremail && k.Password == password);
        }

        public bool UserIsAdmin(User user)
        {
            return user.IsAdminUser;
        }

        public List<User> GetAllUsers(Expression<Func<User, bool>> filter = null, Func<IQueryable<User>, IOrderedQueryable<User>> orderby = null, int skip = 0, int take = 10)
        {
            return _userdal.GetList(filter ?? (x => true), orderby ?? (m => m.OrderByDescending(k => k.Id)), skip, take);
        }

        public int UserCount(Expression<Func<User, bool>> filter = null)
        {
            return _userdal.Count(filter);
        }

        public bool IsUserAndPassword(string usermail, string password)
        {
            return _userdal.Get(k => k.EmailAddress == usermail && k.Password == password) != null;
        }
    }
}
