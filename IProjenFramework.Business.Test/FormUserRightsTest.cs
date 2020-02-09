using System;
using IProjenFramework.Business.Concrete;
using IProjenFramework.Business.DependencyResolvers.Ninject;
using IProjenFramework.DataAccess.Abstract;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IProjenFramework.Business.Test
{
    [TestClass]
    public class FormUserRightsTest
    {
        [TestMethod]
        public void GetAllFormUserRightSets()
        {
            var memberService = InstanceFactory.GetInstance<IFormUserRightsDal>();
            FormUserRightsManager instance = new FormUserRightsManager(memberService);
            var list = instance.GetAllUserFormUserRights(1);
            Assert.AreEqual(4, list.Count);
        }
    }
}
