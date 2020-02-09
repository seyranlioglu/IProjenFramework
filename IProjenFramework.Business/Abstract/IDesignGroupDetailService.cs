using IProjenFramework.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IProjenFramework.Business.Abstract
{
    public interface IDesignGroupDetailService
    {
        void AddDesignGroupDetail(DesignGroupDetail detail);
        void UpdateDesignGroupDetail(DesignGroupDetail detail);
        void DeleteDesignGroupDetail(DesignGroupDetail detail);
        List<DesignGroupDetail> GetAllDesignGroupDetails();
        List<DesignGroupDetail> GetAllDesignGroupDetailsByFormId(int formId);
        List<DesignGroupDetail> GetAllDesignGroupDetailsByDesignId(int designgroupID);
    }
}
