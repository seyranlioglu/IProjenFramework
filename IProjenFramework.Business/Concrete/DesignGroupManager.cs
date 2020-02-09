using IProjenFramework.Business.Abstract;
using IProjenFramework.Core.Aspects.Postsharp.LogAspect;
using IProjenFramework.Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using IProjenFramework.DataAccess.Concrete;
using IProjenFramework.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IProjenFramework.Business.Concrete
{
    public class DesignGroupManager : IDesignGroupService
    {
        private readonly DesignGroupDal _designGroupDal;
        public DesignGroupManager(DesignGroupDal designGroupDal)
        {
            _designGroupDal = designGroupDal;
        }

        [LogAspect(typeof(DatabaseLogger))]
        public void AddDesignGroup(DesignGroup designGroup)
        {
            _designGroupDal.Add(designGroup);
        }

        [LogAspect(typeof(DatabaseLogger))]
        public void DeleteDesignGroup(DesignGroup designGroup)
        {
            _designGroupDal.Delete(designGroup);
        }

        public List<DesignGroup> GetDesignGroups()
        {
            return _designGroupDal.GetList();
        }

        [LogAspect(typeof(DatabaseLogger))]
        public void UpdateDesignGroup(DesignGroup designGroup)
        {
            _designGroupDal.Update(designGroup);
        }
    }
}
