using DevFramework.Core.DataAccess.NHibernate;
using DevFramework.Northwind.DataAccess.Abstract;
using DevFramework.Northwind.Entities.ComplexTypes;
using DevFramework.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
17.Adım
Constructor'ı NHibernateHelper enjekte edibilecek şekilde yazdık. base yani NhEntityRepositoryBase'e helper'ı gönderiyor.
*/
namespace DevFramework.Northwind.DataAccess.Concrete.NHibernate
{
    public class NhProductDAL:NhEntityRepositoryBase<Product>, IProductDal
    {
        private NHibernateHelper _nHibernateHelper;//22.Adım
        public NhProductDAL(NHibernateHelper nHibernateHelper) : base(nHibernateHelper)
        {
            _nHibernateHelper = nHibernateHelper;//22.Adım
        }
        public List<ProductDetail> GetProductDetails()//22.Adım
        {
            using(var session=_nHibernateHelper.OpenSession())
            {
                var result = from p in session.Query<Product>()
                             join c in session.Query<Category>()
                             on p.CategoryId equals c.CategoryID
                             select new ProductDetail
                             {
                                 ProductID = p.ProductId,
                                 ProductName = p.ProductName,
                                 CategoryName = c.CategoryName
                             };
                return result.ToList();        
            }
        }
    }
}