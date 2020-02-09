using IProjenFramework.Business.Abstract;
using IProjenFramework.Core.Aspects.Postsharp.LogAspect;
using IProjenFramework.Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using IProjenFramework.DataAccess.Abstract;
using IProjenFramework.Entities.ComplexType;
using IProjenFramework.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IProjenFramework.Business.Concrete
{
    public class UserPositionManager : IUserPositionService
    {
        private IUserPositionDal _userpositionDal;
        public UserPositionManager(IUserPositionDal userpositionDal)
        {
            _userpositionDal = userpositionDal;
        }

        [LogAspect(typeof(DatabaseLogger))]
        public void AddUserPosition(UserPosition instance)
        {
            _userpositionDal.Add(instance);
        }

        [LogAspect(typeof(DatabaseLogger))]
        public void DeleteUserPosition(UserPosition instance)
        {
            _userpositionDal.Delete(instance);
        }

        [LogAspect(typeof(DatabaseLogger))]
        public void UpdateUserPosition(UserPosition instance)
        {
            _userpositionDal.Update(instance);
        }

        public UserPosition GetUserPositions(int userid)
        {
            return _userpositionDal.Get(k => k.UserId == userid);
        }

        public List<UserPosition> GetUserPositionsByPositionId(int positionId)
        {
            return _userpositionDal.GetList(k => k.PositionId == positionId);
        }

        public List<UserPositionView> GetAllUserPositions(Expression<Func<UserPositionView, bool>> filter = null,
            Func<IQueryable<UserPositionView>, IOrderedQueryable<UserPositionView>> orderby = null, int skip = 10, int take = 10)
        {
            return _userpositionDal.GetAllUserPositionView(filter ?? (x => true), orderby ?? (m => m.OrderByDescending(k => k.Id)), skip, take);
        }

        public UserPosition GetUserPositionById(int Id)
        {
            return _userpositionDal.Get(k => k.Id == Id);
        }
    }
}
