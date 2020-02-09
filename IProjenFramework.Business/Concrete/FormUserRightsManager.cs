using IProjenFramework.Business.Abstract;
using IProjenFramework.Core.Aspects.Postsharp.LogAspect;
using IProjenFramework.Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using IProjenFramework.DataAccess.Abstract;
using IProjenFramework.Entities.ComplexType;
using IProjenFramework.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IProjenFramework.Business.Concrete
{
    public class FormUserRightsManager : IFormUserRightsService
    {
        private IFormUserRightsDal _formUserRightSetDal;
        public FormUserRightsManager(IFormUserRightsDal formUserRightSetDal)
        {
            _formUserRightSetDal = formUserRightSetDal;
        }

        [LogAspect(typeof(DatabaseLogger))]
        public void AddFormUserRightSet(FormUserRightSet instance)
        {
            _formUserRightSetDal.Add(instance);
        }

        [LogAspect(typeof(DatabaseLogger))]
        public void UpdateFormUserRightSet(FormUserRightSet instance)
        {
            _formUserRightSetDal.Update(instance);
        }

        [LogAspect(typeof(DatabaseLogger))]
        public void DeleteFormUserRightSet(int Id)
        {
            _formUserRightSetDal.Delete(_formUserRightSetDal.Get(k => k.Id == Id));
        }

        public List<FormUserRightSetView> GetAllFormUserRightsByDepartmentId(int departmentid)
        {
            return _formUserRightSetDal.GetFormRightSetOfDepartment(departmentid);
        }

        public List<FormUserRightSetView> GetAllFormUserRightsByUserId(int userid)
        {
            return _formUserRightSetDal.GetFormRightSetOfUser(userid);
        }

        public List<FormUserRightSetView> GetAllFormUserRightsByPositionId(int positionId)
        {
            return _formUserRightSetDal.GetFormRightSetOfPosition(positionId);
        }
        
        public List<FormUserRightSet> GetFormUserRightSets()
        {
            return _formUserRightSetDal.GetList();
        }

        public List<FormUserRightSetView> GetAllUserFormUserRights(int userid)
        {
            return _formUserRightSetDal.GetAllFormUserRightSetByUserId(userid);
        }
        
    }
}
