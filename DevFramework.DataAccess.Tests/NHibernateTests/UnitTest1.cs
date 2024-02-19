using DevFramework.Northwind.DataAccess.Concrete.EntityFramework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using DevFramework.Northwind.Entities;
using DevFramework.Northwind.DataAccess.Concrete.NHibernate.Helpers;
using DevFramework.Northwind.DataAccess.Concrete.NHibernate;
/*
14.Adım  
*/
namespace DevFramework.DataAccess.Tests.NHibernateTests
{
    [TestClass]
    public class NHibernateTest
    {
        [TestMethod]
        public void Get_all_returns_all_products()
        {
            NhProductDAL productDal=new NhProductDAL(new SqlServerHelper());
            var result = productDal.GetList();
            Assert.AreEqual(77, result.Count);
        }
        [TestMethod]
        public void Get_all_with_parameter_returns_filtered_products()
        {
            NhProductDAL productDal = new NhProductDAL(new SqlServerHelper());
            var result = productDal.GetList(p=>p.ProductName.Contains("ab"));
            Assert.AreEqual(4, result.Count);
        }
    }
}