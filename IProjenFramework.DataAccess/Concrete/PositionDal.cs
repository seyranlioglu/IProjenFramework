using IProjenFramework.Core.DataAccess.EntityFramework;
using IProjenFramework.DataAccess.Abstract;
using IProjenFramework.DataAccess.Concrete.Context;
using IProjenFramework.Entities.ComplexType;
using IProjenFramework.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IProjenFramework.DataAccess.Concrete
{
    public class PositionDal : EfEntityRepositoryBase<Position, IProjenFrameworkContext>, IPositionDal
    {
        public List<PositionView> GetAllPositionsView(Expression<Func<PositionView, bool>> filter, Func<IQueryable<PositionView>, IOrderedQueryable<PositionView>> orderBy = null, int skip = 0, int take = 0)
        {
            using(var context = new IProjenFrameworkContext())
            {
                var positionview = from ps in context.Positions
                                   join dp in context.Departments
                                   on ps.DepartmentId equals dp.Id into dps
                                   from dp in dps.DefaultIfEmpty()
                                   select new PositionView
                                   {
                                       Id = ps.Id,
                                       Name = ps.Name,
                                       Description = ps.Description,
                                       DepartmentName = dp.Name,
                                       DepartmentId = ps.DepartmentId
                                   };
                return orderBy(positionview.Where(filter)).Take(take).Skip(skip).ToList();
            }
        }

        public List<Position> GetPositionsByDepartmentId(int departmentid)
        {
            using(IProjenFrameworkContext context = new IProjenFrameworkContext())
            {
                var positions = from ps in context.Positions
                                where ps.DepartmentId == departmentid
                                select ps;
                return positions.ToList();
            }
        }

        public List<Position> GetPositionsByUserId(int userid)
        {
            using (IProjenFrameworkContext context = new IProjenFrameworkContext())
            {
                var positions = from ps in context.Positions
                                join up in context.UserPositions on ps.Id equals up.PositionId
                                join us in context.Users on up.UserId equals us.Id
                                select ps;
                return positions.ToList();
            }
        }

        public int GetAllPositionsViewCount(Expression<Func<PositionView, bool>> filter = null)
        {
            using (var context = new IProjenFrameworkContext())
            {
                var positionview = from ps in context.Positions
                                   join dp in context.Departments
                                   on ps.DepartmentId equals dp.Id into dps
                                   from dp in dps.DefaultIfEmpty()
                                   select new PositionView
                                   {
                                       Id = ps.Id,
                                       Name = ps.Name,
                                       Description = ps.Description,
                                       DepartmentName = dp.Name,
                                       DepartmentId = ps.DepartmentId
                                   };
                return filter == null
                    ? positionview.Count()
                    : positionview.Count(filter);
            }
        }

    }
}
