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
    public interface IPositionDal : IEntityRepository<Position>
    {
        List<Position> GetPositionsByDepartmentId(int departmentid);
        List<Position> GetPositionsByUserId(int userid);
        List<PositionView> GetAllPositionsView(Expression<Func<PositionView, bool>> filter = null, Func<IQueryable<PositionView>, IOrderedQueryable<PositionView>> orderBy = null, int skip = 0, int take = 0);

        int GetAllPositionsViewCount(Expression<Func<PositionView, bool>> filter = null);
    }
}
