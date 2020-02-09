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
    public class FormUserRightSetDal : EfEntityRepositoryBase<FormUserRightSet, IProjenFrameworkContext>, IFormUserRightsDal
    {
        // Tek Departmana ait form yetkileri <<< Departman yetkileri formu için
        public List<FormUserRightSetView> GetFormRightSetOfDepartment(int departmentid)
        {
            using(var context = new IProjenFrameworkContext())
            {
                var departmentrights = from dp in context.FormUserRightSets
                                       join frm in context.Forms on dp.FormId equals frm.Id
                                       where dp.UserType == FormUserRightSet.UserTypes.Department
                                       && dp.UserId == departmentid
                                       select new FormUserRightSetView
                                       {
                                           Id = dp.Id,
                                           FormId = dp.FormId,
                                           UserId = dp.UserId,
                                           ViewRight = dp.ViewRight,
                                           DeleteRight = dp.DeleteRight,
                                           InsertRight = dp.InsertRight,
                                           UpdateRight = dp.UpdateRight,
                                           FormName = frm.Name,
                                       };
                return departmentrights.ToList();
            }
        }

        // Tek Pozisyona ait form yetkileri <<< Pozisyon yetkileri formu için
        public List<FormUserRightSetView> GetFormRightSetOfPosition(int positionId)
        {
            using (var context = new IProjenFrameworkContext())
            {
                var userpositionrights = from dp in context.FormUserRightSets
                                         join frm in context.Forms on dp.FormId equals frm.Id
                                         where dp.UserType == FormUserRightSet.UserTypes.Position
                                         && dp.UserId == positionId
                                         select new FormUserRightSetView
                                         {
                                             Id = dp.Id,
                                             FormId = dp.FormId,
                                             UserId = dp.UserId,
                                             ViewRight = dp.ViewRight,
                                             DeleteRight = dp.DeleteRight,
                                             InsertRight = dp.InsertRight,
                                             UpdateRight = dp.UpdateRight,
                                             FormName = frm.Name,
                                         };
                return userpositionrights.ToList();
            }
        }

        // Tek Kullanıcıya ait form yetkileri <<< Kullanıcı yetkileri formu için
        public List<FormUserRightSetView> GetFormRightSetOfUser(int userid)
        {
            using (var context = new IProjenFrameworkContext())
            {
                var userrights = from dp in context.FormUserRightSets
                                 join frm in context.Forms on dp.FormId equals frm.Id
                                 where dp.UserType == FormUserRightSet.UserTypes.User
                                 && dp.UserId == userid
                                 select new FormUserRightSetView
                                 {
                                     Id = dp.Id,
                                     FormId = dp.FormId,
                                     UserId = dp.UserId,
                                     ViewRight = dp.ViewRight,
                                     DeleteRight = dp.DeleteRight,
                                     InsertRight = dp.InsertRight,
                                     UpdateRight = dp.UpdateRight,
                                     FormName = frm.Name,
                                 };
                return userrights.ToList();
            }
        }

        // Kullanıcının tüm form yetkileri (Departman + Pozisyon + Kullanıcı)
        public List<FormUserRightSetView> GetAllFormUserRightSetByUserId(int userid)
        {
            using (var context = new IProjenFrameworkContext())
            {
                var formUserRightSets = (from dp in context.Departments
                                         join po in context.Positions on dp.Id equals po.DepartmentId
                                         join up in context.UserPositions on po.Id equals up.PositionId
                                         join us in context.Users on up.UserId equals us.Id
                                         join frm in context.FormUserRightSets on dp.Id equals frm.UserId
                                         join form in context.Forms on frm.FormId equals form.Id
                                         where us.Id == userid && frm.UserType == FormUserRightSet.UserTypes.Department
                                         && form.Locked == false
                                         select new FormUserRightSetView
                                         {
                                             Id = frm.Id,
                                             FormId = frm.FormId,
                                             UserId = frm.UserId,
                                             ViewRight = frm.ViewRight,
                                             DeleteRight = frm.DeleteRight,
                                             InsertRight = frm.InsertRight,
                                             UpdateRight = frm.UpdateRight,
                                             FormName = form.Name,
                                         }).Union
                                         (from po in context.Positions
                                          join up in context.UserPositions on po.Id equals up.PositionId
                                          join us in context.Users on up.UserId equals us.Id
                                          join frm in context.FormUserRightSets on po.Id equals frm.UserId
                                          join form in context.Forms on frm.FormId equals form.Id
                                          where us.Id == userid && frm.UserType == FormUserRightSet.UserTypes.Position
                                          && form.Locked == false
                                          select new FormUserRightSetView
                                          {
                                              Id = frm.Id,
                                              FormId = frm.FormId,
                                              UserId = frm.UserId,
                                              ViewRight = frm.ViewRight,
                                              DeleteRight = frm.DeleteRight,
                                              InsertRight = frm.InsertRight,
                                              UpdateRight = frm.UpdateRight,
                                              FormName = form.Name,
                                          }).Union
                                          (from  us in context.Users
                                           join frm in context.FormUserRightSets on us.Id equals frm.UserId
                                           join form in context.Forms on frm.FormId equals form.Id
                                           where frm.UserId == userid && frm.UserType == FormUserRightSet.UserTypes.User
                                           && form.Locked == false
                                           select new FormUserRightSetView
                                           {
                                               Id = frm.Id,
                                               FormId = frm.FormId,
                                               UserId = frm.UserId,
                                               ViewRight = frm.ViewRight,
                                               DeleteRight = frm.DeleteRight,
                                               InsertRight = frm.InsertRight,
                                               UpdateRight = frm.UpdateRight,
                                               FormName = form.Name,
                                           });
                return formUserRightSets.ToList();
            }
        }

    }
}
