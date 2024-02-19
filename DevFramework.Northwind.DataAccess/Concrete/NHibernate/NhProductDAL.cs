using DevFramework.Core.DataAccess.NHibernate;
using DevFramework.Northwind.DataAccess.Abstract;
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
        public NhProductDAL(NHibernateHelper nHibernateHelper) : base(nHibernateHelper)
        {
            
        }
    }
}