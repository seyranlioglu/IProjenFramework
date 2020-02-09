using IProjenFramework.Core.DataAccess;
using IProjenFramework.Entities.ComplexType;
using IProjenFramework.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IProjenFramework.DataAccess.Abstract
{
    public interface IFormUserRightsDal : IEntityRepository<FormUserRightSet>
    {
        List<FormUserRightSetView> GetFormRightSetOfDepartment(int departmentid);
        List<FormUserRightSetView> GetFormRightSetOfPosition(int positionId);
        List<FormUserRightSetView> GetFormRightSetOfUser(int userid);
        List<FormUserRightSetView> GetAllFormUserRightSetByUserId(int userid);
    }
}
