[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(DevFramework.Northwind.WebApi.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(DevFramework.Northwind.WebApi.App_Start.NinjectWebCommon), "Stop")]
namespace DevFramework.Northwind.WebApi.App_Start
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Http;
    using DevFramework.Northwind.Business.DependencyResolvers.Ninject;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;
    using Ninject;
    using Ninject.Web.Common;
    using Ninject.Web.Common.WebHost;
    using WebApiContrib.IoC.Ninject;

    public static class NinjectWebCommon
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();
        ///Starts the application
        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        ///Stops the application
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        ///Creates the kernel that will manage your application
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();
                GlobalConfiguration.Configuration.DependencyResolver = new NinjectResolver(kernel);
                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }
        ///Load your modules or register your services here
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Load(new BusinessModule(),new AutoMapperModule());
        }
    }
}