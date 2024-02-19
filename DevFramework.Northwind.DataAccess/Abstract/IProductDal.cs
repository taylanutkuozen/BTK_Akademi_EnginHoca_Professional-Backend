using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevFramework.Core.DataAccess;
using DevFramework.Northwind.Entities.Concrete;
/*
 9.Sırada
 */
namespace DevFramework.Northwind.DataAccess.Abstract
{
    public interface IProductDal : IEntityRepository<Product> /**/
    {
        //IProductDal a özgü işlemler yapıbilmek için burada komutlar yazabiliriz.
    }
}