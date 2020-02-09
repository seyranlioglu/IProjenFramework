using IProjenFramework.Core.DataAccess;
using IProjenFramework.Entities.ComplexType;
using IProjenFramework.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IProjenFramework.DataAccess.Abstract
{
    public interface IUserPositionDal : IEntityRepository<UserPosition>
    {
        List<UserPositionView> GetAllUserPositionView(Expression<Func<UserPositionView, bool>> filter = null, Func<IQueryable<UserPositionView>, IOrderedQueryable<UserPositionView>> orderBy = null, int skip = 0, int take = 0);
    }
}
