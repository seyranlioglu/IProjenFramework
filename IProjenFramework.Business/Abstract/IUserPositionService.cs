using IProjenFramework.Entities.ComplexType;
using IProjenFramework.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IProjenFramework.Business.Abstract
{
    public interface IUserPositionService
    {
        List<UserPositionView> GetAllUserPositions(Expression<Func<UserPositionView, bool>> filter = null,
            Func<IQueryable<UserPositionView>, IOrderedQueryable<UserPositionView>> orderby = null, int skip = 0, int take = 10);
        UserPosition GetUserPositions(int userid);
        UserPosition GetUserPositionById(int Id);
        void AddUserPosition(UserPosition instance);
        void UpdateUserPosition(UserPosition instance);
        void DeleteUserPosition(UserPosition instance);
        List<UserPosition> GetUserPositionsByPositionId(int positionId);
    }
}
