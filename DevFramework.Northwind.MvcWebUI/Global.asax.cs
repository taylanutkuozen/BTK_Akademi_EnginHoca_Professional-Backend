using DevFramework.Core.Utilities.Mvc.Infrastructure;
using DevFramework.Northwind.Business.DependencyResolvers.Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
/*
45.Adım 
*/
namespace DevFramework.Northwind.MvcWebUI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            ControllerBuilder.Current.SetControllerFactory(new NinjectControllerFactory(new BusinessModule()));//45.Adım
            //var builder = new ContainerBuilder();

       //     // Controllers
       //     builder.RegisterControllers(typeof(MvcApplication).Assembly);

       //     // Data Access
       //     builder.RegisterType<EfProductDal>().As<IProductDal>();
       //     var businessAssembly = typeof(ProductManager).Assembly;
       //     var dataAssembly = typeof(EfProductDal).Assembly;
       //     // Business + Interception (Aspect'lerin çalışması için kritik kısım)
       //     //builder.RegisterType<ProductManager>()
       //     //       .As<IProductService>()
       //     //       .EnableInterfaceInterceptors()
       //     //       .InterceptedBy(typeof(AspectInterceptorSelector));
       //     builder.RegisterAssemblyTypes(businessAssembly)
       //.AsImplementedInterfaces()
       //.EnableInterfaceInterceptors(new ProxyGenerationOptions
       //{
       //    Selector = new AspectInterceptorSelector()
       //})
       //.SingleInstance();
       //     builder.RegisterAssemblyTypes(dataAssembly)
       //.AsImplementedInterfaces()
       //.SingleInstance();
       //     // Gerekirse diğer manager'ları da aynı şekilde ekleyin
       //     //builder.RegisterType<CategoryManager>()
       //     //       .As<ICategoryService>()
       //     //       .EnableInterfaceInterceptors()
       //     //       .InterceptedBy(typeof(AspectInterceptorSelector));

       //     // AspectInterceptorSelector'ı da kaydediyoruz
       //     builder.RegisterType<AspectInterceptorSelector>();

       //     var container = builder.Build();
       //     DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}