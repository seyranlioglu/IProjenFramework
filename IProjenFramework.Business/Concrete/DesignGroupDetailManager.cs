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
    public class DesignGroupDetailManager : IDesignGroupDetailService
    {
        private readonly DesignGroupDetailDal _designGroupDetailDal;
        public DesignGroupDetailManager(DesignGroupDetailDal designGroupDetailDal)
        {
            _designGroupDetailDal = designGroupDetailDal;
        }
        [LogAspect(typeof(DatabaseLogger))]
        public void AddDesignGroupDetail(DesignGroupDetail detail)
        {
            _designGroupDetailDal.Add(detail);
        }

        [LogAspect(typeof(DatabaseLogger))]
        public void DeleteDesignGroupDetail(DesignGroupDetail detail)
        {
            _designGroupDetailDal.Delete(detail);
        }

        public List<DesignGroupDetail> GetAllDesignGroupDetails()
        {
            return _designGroupDetailDal.GetList();
        }

        public List<DesignGroupDetail> GetAllDesignGroupDetailsByDesignId(int designgroupID)
        {
            return _designGroupDetailDal.GetList(k => k.DesignGroupId == designgroupID);
        }

        public List<DesignGroupDetail> GetAllDesignGroupDetailsByFormId(int formId)
        {
            return _designGroupDetailDal.GetList(k => k.FormId == formId);
        }

        [LogAspect(typeof(DatabaseLogger))]
        public void UpdateDesignGroupDetail(DesignGroupDetail detail)
        {
            _designGroupDetailDal.Update(detail);
        }
    }
}
