using DevFramework.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
/*
21.Adım= ProductManager'a bağlı kalmadan üst layer'lar IProductService ile haberleşecektir. 
*/
namespace DevFramework.Northwind.Business.Abstract
{
    [ServiceContract]//WCF Service yapabilmek icin
    public interface IProductService
    {
        [OperationContract] //WCF Service yapabilmek icin
        List<Product> GetAllProducts();
        [OperationContract]
        Product GetByID(int id);
        [OperationContract]
        Product Add(Product product);
        [OperationContract]
        Product Update(Product product);///24.Adım
        [OperationContract]
        void TransactionalOperation(Product product1, Product product2);//29.Adım
    }
}