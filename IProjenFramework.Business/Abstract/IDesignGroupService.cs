using IProjenFramework.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IProjenFramework.Business.Abstract
{
    public interface IDesignGroupService
    {
        void AddDesignGroup(DesignGroup designGroup);
        void UpdateDesignGroup(DesignGroup designGroup);
        void DeleteDesignGroup(DesignGroup designGroup);
        List<DesignGroup> GetDesignGroups();

    }
}
