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
    public class UserPositionDal : EfEntityRepositoryBase<UserPosition, IProjenFrameworkContext>, IUserPositionDal
    {
        public List<UserPositionView> GetAllUserPositionView(Expression<Func<UserPositionView, bool>> filter = null, Func<IQueryable<UserPositionView>, IOrderedQueryable<UserPositionView>> orderBy = null, int skip = 0, int take = 0)
        {
            using(var context = new IProjenFrameworkContext())
            {
                var positionview = from up in context.UserPositions
                                   join u in context.Users
                                   on up.UserId equals u.Id into ups
                                   from u in ups.DefaultIfEmpty()
                                   join p in context.Positions
                                   on up.PositionId equals p.Id into pps
                                   from p in pps.DefaultIfEmpty()
                                   select new UserPositionView
                                   {
                                       Id = up.Id,
                                       PositionId = up.PositionId,
                                       UserId = up.UserId,
                                       UserName = u.Name,
                                       PositionName = p.Name
                                   };
                return orderBy(positionview.Where(filter)).Take(take).Skip(skip).ToList();
            }
        }

        public List<Position> GetUserPositionsByUserId(int userid)
        {
            using(IProjenFrameworkContext context = new IProjenFrameworkContext())
            {
                var model = from up in context.UserPositions
                            where up.UserId == userid
                            select up.Position;
                return model.ToList();
            }
        }
    }
}
