using IProjenFramework.Entities.ComplexType;
using IProjenFramework.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IProjenFramework.Business.Abstract
{
    public interface IFormUserRightsService
    {
        List<FormUserRightSet> GetFormUserRightSets();
        List<FormUserRightSetView> GetAllFormUserRightsByUserId(int userid);
        List<FormUserRightSetView> GetAllFormUserRightsByPositionId(int positionId);
        List<FormUserRightSetView> GetAllFormUserRightsByDepartmentId(int departmentid);
        List<FormUserRightSetView> GetAllUserFormUserRights(int userid);
        void AddFormUserRightSet(FormUserRightSet instance);
        void UpdateFormUserRightSet(FormUserRightSet instance);
        void DeleteFormUserRightSet(int Id);
    }
}
