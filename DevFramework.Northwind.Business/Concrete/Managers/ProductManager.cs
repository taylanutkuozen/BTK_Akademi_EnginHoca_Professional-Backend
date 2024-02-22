using DevFramework.Core.CrossCuttingConcerns.Validation.FluentValidation;
using DevFramework.Northwind.Business.Abstract;
using DevFramework.Northwind.Business.ValidationRules.FluentValidation;
using DevFramework.Northwind.DataAccess.Abstract;
using DevFramework.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//21.Adım
namespace DevFramework.Northwind.Business.Concrete.Managers
{
    public class ProductManager : IProductService
    {
        private  IProductDal _productDal;
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal; //Dependency Injection
        }
        [FluentValidate(typeof(ProductValidator))]//24.Adım bir tane aspect yazıyoruz.
        public Product Add(Product product)
        {
            return _productDal.Add(product);
        }
        public List<Product> GetAllProducts()
        {
            return _productDal.GetList();
        }
        public Product GetByID(int id)
        {
            return _productDal.Get(p=>p.ProductId==id);
        }
        [FluentValidate(typeof(ProductValidator))]
        public Product Update(Product product) //24.Adım
        {
            return _productDal.Update(product);
        }
    }
}