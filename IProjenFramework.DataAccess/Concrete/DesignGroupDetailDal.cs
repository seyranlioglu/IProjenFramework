using IProjenFramework.Core.DataAccess.EntityFramework;
using IProjenFramework.DataAccess.Abstract;
using IProjenFramework.DataAccess.Concrete.Context;
using IProjenFramework.Entities.ComplexType;
using IProjenFramework.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IProjenFramework.DataAccess.Concrete
{
    public class DesignGroupDetailDal : EfEntityRepositoryBase<DesignGroupDetail, IProjenFrameworkContext>, IDesignGroupDetailDal
    {
        public List<DesignGroupDetailView> GetAllDesignGroupDetailView()
        {
            using(var context = new IProjenFrameworkContext())
            {
                var detailViews =
                    from detail in context.DesignGroupDetails
                    join designs in context.DesignGroups
                    on detail.DesignGroupId equals designs.Id
                    join forms in context.Forms on detail.FormId equals forms.Id
                    select new DesignGroupDetailView
                    {
                        Id = detail.Id,
                        FormName = forms.Name,
                        DesignGroupName = designs.Name
                    };
                return detailViews.ToList();
            }
        }
    }
}
