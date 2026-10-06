using AutoMapper;
using DevFramework.Core.Aspects.Postsharp;
using DevFramework.Core.Aspects.Postsharp.AuthorizationAspects;
using DevFramework.Core.Aspects.Postsharp.CacheAspects;
using DevFramework.Core.Aspects.Postsharp.LogAspects;
using DevFramework.Core.Aspects.Postsharp.TransactionAspects;
using DevFramework.Core.CrossCuttingConcerns.Caching.Microsoft;
using DevFramework.Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using DevFramework.Core.CrossCuttingConcerns.Validation.FluentValidation;
using DevFramework.Core.PerformanceAspects;
using DevFramework.Core.Utilities.Mappings;
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
        private readonly IMapper _mapper;
        public ProductManager(IProductDal productDal,IMapper mapper)
        {
            _productDal = productDal; //Dependency Injection
            _mapper = mapper;
        }
        [FluentValidationAspect(typeof(ProductValidator))]//24.Adım bir tane aspect yazıyoruz.
        [CacheRemoveAspect(typeof(MemoryCacheManager))]//34.Adım
        //[LogAspect(typeof(FileLogger))]
        public Product Add(Product product)
        {
            return _productDal.Add(product);
        }
        [CacheAspect(typeof(MemoryCacheManager))]
        [LogAspect(typeof(DatabaseLogger))]//41.Adım
        [LogAspect(typeof(FileLogger))] //42.Adım
        [PerformanceCounterAspect(2/*interval icin 2 saniye verdik default 5 yerine*/)]
        [SecuredOperation(Roles="Admin,Editor")]
        public List<Product> GetAllProducts()
        {
            //return _productDal.GetList();
            //return _productDal.GetList().Select(p => new Product
            //{
            //    CategoryId=p.CategoryId,
            //    ProductId=p.ProductId,
            //    ProductName=p.ProductName,
            //    QuantityPerUnit=p.QuantityPerUnit,
            //    UnitPrice=p.UnitPrice
            //}).ToList();Serilestirme problemini asmak icin bunu kullandik
            //var products = AutoMapperHelper.MapToSameTypeList(_productDal.GetList());
            var products = _mapper.Map<List<Product>>(_productDal.GetList());//-->Dependency Injection Version
            return products;
        }
        public Product GetByID(int id)
        {
            return _productDal.Get(p=>p.ProductId==id);
        }
        [TransactionScopeAspect]
        [FluentValidationAspect(typeof(ProductValidator))]
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