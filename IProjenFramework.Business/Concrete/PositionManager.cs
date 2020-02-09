using IProjenFramework.Business.Abstract;
using IProjenFramework.Business.ValidationRules.FluentValidation;
using IProjenFramework.Core.Aspects.Postsharp.CacheAspect;
using IProjenFramework.Core.Aspects.Postsharp.LogAspect;
using IProjenFramework.Core.Aspects.Postsharp.ValidationAspect;
using IProjenFramework.Core.CrossCuttingConcerns.Caching.Microsoft;
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
    public class PositionManager : IPositionService
    {
        private readonly IPositionDal _positionDal;
        public PositionManager(IPositionDal positionDal)
        {
            _positionDal = positionDal;
        }

        [FluentValidationAspect(typeof(PositionValidator))]
        [LogAspect(typeof(DatabaseLogger))]
        public void AddPosition(Position position)
        {
            _positionDal.Add(position);
        }

        [FluentValidationAspect(typeof(PositionValidator))]
        [LogAspect(typeof(DatabaseLogger))]
        public void UpdatePosition(Position position)
        {
            _positionDal.Update(position);
        }

        [LogAspect(typeof(DatabaseLogger))]
        public void DeletePosition(Position position)
        {
            _positionDal.Delete(position);
        }
        public List<PositionView> GetAllPositions(Expression<Func<PositionView, bool>> filter = null,
            Func<IQueryable<PositionView>, IOrderedQueryable<PositionView>> orderby = null, int skip = 10, int take = 10)
        {
            return _positionDal.GetAllPositionsView(filter ?? (x => true), orderby, skip, take);
        }

        public List<Position> GetAllPositionsByDepartmentId(int departmentId)
        {
            return _positionDal.GetPositionsByDepartmentId(departmentId);
        }

        public Position GetPositionById(int Id)
        {
            return _positionDal.Get(k => k.Id == Id);
        }

        public int GetPositionViewCount(Expression<Func<PositionView, bool>> filter = null)
        {
            return _positionDal.GetAllPositionsViewCount(filter);
        }
    }
}
