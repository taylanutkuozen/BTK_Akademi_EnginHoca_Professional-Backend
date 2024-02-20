using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevFramework.Core.DataAccess;
using DevFramework.Northwind.Entities.ComplexTypes;
using DevFramework.Northwind.Entities.Concrete;
/*
9.Adım
*/
namespace DevFramework.Northwind.DataAccess.Abstract
{
    public interface IProductDal : IEntityRepository<Product> /*21.Adım*/
    {
        //IProductDal a özgü işlemler yapıbilmek için burada komutlar yazabiliriz.
        List<ProductDetail> GetProductDetails();
    }
}