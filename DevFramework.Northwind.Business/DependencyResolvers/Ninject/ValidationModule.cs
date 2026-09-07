using DevFramework.Northwind.Business.ValidationRules.FluentValidation;
using DevFramework.Northwind.Entities.Concrete;
using FluentValidation;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
29.Adım 
*/
namespace DevFramework.Northwind.Business.DependencyResolvers.Ninject
{
    public class ValidationModule:NinjectModule
    {
        public override void Load()
        {
            try
            {
                Bind<IValidator<Product>>().To<ProductValidator>();//.InSingletonScope();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);  
            }
        }
    }
}