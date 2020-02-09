using IProjenFramework.Business.Concrete;
using IProjenFramework.Business.DependencyResolvers.Ninject;
using IProjenFramework.DataAccess.Abstract;
using IProjenFramework.Entities.Concrete;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IProjenFramework.Business.Test
{
    [TestClass]
    public class DepartmentTest
    {
        

        [TestMethod]
        public void UpdateDepartmentForLogTest()
        {
            var memberService = InstanceFactory.GetInstance<IDepartmentDal>();
            DepartmentManager instance = new DepartmentManager(memberService);
            Department dp = new Department();
            dp = instance.GetDepartmentById(1);
            dp.CreateDate = DateTime.Now;
            instance.UpdateDepartment(dp);
        }
    }
}
