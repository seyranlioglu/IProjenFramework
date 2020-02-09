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
    public interface IPositionService
    {
        void AddPosition(Position position);
        void UpdatePosition(Position position);
        void DeletePosition(Position position);
        List<PositionView> GetAllPositions(Expression<Func<PositionView, bool>> filter = null,
            Func<IQueryable<PositionView>, IOrderedQueryable<PositionView>> orderby = null, int skip = 0, int take = 0);
        Position GetPositionById(int Id);
        List<Position> GetAllPositionsByDepartmentId(int departmentId);
        int GetPositionViewCount(Expression<Func<PositionView, bool>> filter = null);
    }
}
