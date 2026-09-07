using Castle.DynamicProxy;
using DevFramework.Core.DataAccess;
using DevFramework.Core.DataAccess.EntityFramework;
using DevFramework.Core.DataAccess.NHibernate;
using DevFramework.Core.Utilities.Interceptors;
using DevFramework.Northwind.Business.Abstract;
using DevFramework.Northwind.Business.Concrete.Managers;
using DevFramework.Northwind.DataAccess.Abstract;
using DevFramework.Northwind.DataAccess.Concrete.EntityFramework;
using DevFramework.Northwind.DataAccess.Concrete.NHibernate;
using DevFramework.Northwind.DataAccess.Concrete.NHibernate.Helpers;
using DevFramework.Northwind.Entities.Concrete;
using Ninject;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
28.Adım = Arayüz (Business-DataAccess) için tasarım yapılıyor. 
*/
namespace DevFramework.Northwind.Business.DependencyResolvers.Ninject
{
    public class BusinessModule : NinjectModule
    {
        private readonly ProxyGenerator _proxyGenerator = new ProxyGenerator();
        public override void Load()
        {
            Bind<IProductService>().ToMethod(context =>
            {
                var target = context.Kernel.Get<ProductManager>();
                var proxy = _proxyGenerator.CreateInterfaceProxyWithTarget<IProductService>(target,
                    new ProxyGenerationOptions
                    {
                        Selector = new AspectInterceptorSelector(typeof(ProductManager))
                    });
                return proxy;
            }).InSingletonScope();
            Bind<ProductManager>().ToSelf().InSingletonScope();
            //Bind<IProductService>().To<ProductManager>().InSingletonScope(); //InSıngletonScope eklemez isek her istekte newleme işlemi yapılır. Bir IProductService instance'ı oluşturulduğunda ProductManagerdan bir instance al(nesne oluştur.)
            Bind<IProductDal>().To<EfProductDal>();
            ////Bind<IProductDal>().To<NhProductDAL>();
            Bind(typeof(IQueryableRepository<>)).To(typeof(EfQueryableRepository<>));
            //Bind(typeof(IQueryableRepository<>)).To(typeof(NhQuaryableRepository<>));
            Bind<DbContext>().To<NorthwindContext>();
            Bind<NHibernateHelper>().To<SqlServerHelper>();
        }
    }
}