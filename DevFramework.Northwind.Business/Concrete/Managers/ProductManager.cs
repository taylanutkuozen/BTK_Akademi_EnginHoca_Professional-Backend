using DevFramework.Core.Aspects.Postsharp;
using DevFramework.Core.Aspects.Postsharp.CacheAspects;
using DevFramework.Core.Aspects.Postsharp.LogAspects;
using DevFramework.Core.Aspects.Postsharp.TransactionAspects;
using DevFramework.Core.CrossCuttingConcerns.Caching.Microsoft;
using DevFramework.Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
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
using System.Transactions;
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
        [FluentValidationAspect(typeof(ProductValidator))]//24.Adım bir tane aspect yazıyoruz.
        [CacheRemoveAspect(typeof(MemoryCacheManager))]//34.Adım
        public Product Add(Product product)
        {
            return _productDal.Add(product);
        }
        [CacheAspect(typeof(MemoryCacheManager))]
        [LogAspect(typeof(DatabaseLogger))]//41.Adım
        [LogAspect(typeof(FileLogger))] //42.Adım
        public List<Product> GetAllProducts()
        {
            return _productDal.GetList();
        }
        public Product GetByID(int id)
        {
            return _productDal.Get(p=>p.ProductId==id);
        }
        [TransactionScopeAspect]
        public void TransactionalOperation(Product product1, Product product2) //29.Adım
        {
            _productDal.Add(product1);
            //BusinessCodes
            _productDal.Update(product2);
            /*using (TransactionScope scope=new TransactionScope())
            {
                try
                {
                    _productDal.Add(product1);
                    //BusinessCodes
                    _productDal.Update(product2);
                    scope.Complete();
                }
                catch
                {
                    scope.Dispose();
                }
            }-->Çok kompleks*/
        }
        [FluentValidationAspect(typeof(ProductValidator))]
        public Product Update(Product product) //24.Adım
        {
            return _productDal.Update(product);
        }
    }
}