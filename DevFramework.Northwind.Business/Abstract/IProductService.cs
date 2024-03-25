using DevFramework.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
21.Adım= ProductManager'a bağlı kalmadan üst layer'lar IProductService ile haberleşecektir. 
*/
namespace DevFramework.Northwind.Business.Abstract
{
    public interface IProductService
    {
        List<Product> GetAllProducts();
        Product GetByID(int id);
        Product Add(Product product);
        Product Update(Product product);///24.Adım
        void TransactionalOperation(Product product1, Product product2);//29.Adım
    }
}