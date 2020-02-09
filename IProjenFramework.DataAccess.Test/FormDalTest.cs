using System;
using IProjenFramework.DataAccess.Abstract;
using IProjenFramework.DataAccess.Concrete;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IProjenFramework.DataAccess.Test
{
    [TestClass]
    public class FormDalTest
    {
        [TestMethod]
        public void GetAllForms()
        {
            IFormDal formDal = new FormDal();
            var result = formDal.GetList();
            Assert.AreEqual(3, result.Count);
        }
    }
}
