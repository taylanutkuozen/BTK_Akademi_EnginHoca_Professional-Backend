//using Castle.DynamicProxy;
//using DevFramework.Core.Aspects.Postsharp.ExceptionAspects;
//using DevFramework.Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Reflection;
//using System.Text;
//using System.Threading.Tasks;
//namespace DevFramework.Core.Utilities.Interceptors
//{
//    public class AspectInterceptorSelector : IInterceptorSelector
//    {
//        private readonly Type _targetType;
//        public AspectInterceptorSelector(Type targetType)
//        {
//            _targetType = targetType;
//        }
//        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
//        {
//            var targetMethod = method;
//            if(type.IsInterface)
//            {
//                targetMethod=_targetType
//                    .GetMethod(method.Name,method.GetParameters().Select(x=>x.ParameterType).ToArray());
//            }
//                        //        throw new Exception(
//                        //"SELECTOR ÇALIŞTI: " +
//                        //type.FullName +
//                        //" / " +
//                        //method.Name
//                    //);
//            var classAttributes = _targetType.GetCustomAttributes<MethodInterceptionBaseAttribute>(true).ToList();
//            //var methodAttributes = type.GetMethod(method.Name).GetCustomAttributes<MethodInterceptionBaseAttribute>(true);
//            var methodAttributes = targetMethod.GetCustomAttributes<MethodInterceptionBaseAttribute>(true);
//            classAttributes.AddRange(methodAttributes);
//            classAttributes.Add(new ExceptionLogAspect(typeof(FileLogger)));
//            var result= classAttributes.OrderBy(x => x.Priority).Cast<IInterceptor>().ToArray();
//            throw new Exception(
//    "INTERCEPTOR SAYISI = " + result.Length +
//    " / " +
//    string.Join(", ", result.Select(x => x.GetType().FullName))
//);
//            return result;
//        }
//    }
//}
using Castle.DynamicProxy;
using DevFramework.Core.Aspects.Postsharp.ExceptionAspects;
using DevFramework.Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
namespace DevFramework.Core.Utilities.Interceptors
{
    public class AspectInterceptorSelector : IInterceptorSelector
    {
        private readonly Type _targetType;

        public AspectInterceptorSelector(Type targetType)
        {
            _targetType = targetType;
        }

        public IInterceptor[] SelectInterceptors(
            Type type,
            MethodInfo method,
            IInterceptor[] interceptors)
        {
            var targetMethod = _targetType.GetMethod(
                method.Name,
                method.GetParameters()
                    .Select(x => x.ParameterType)
                    .ToArray()
            );
            if (targetMethod == null)
            {
                return new IInterceptor[0];
            }
            var attributes =
                _targetType
                    .GetCustomAttributes<MethodInterceptionBaseAttribute>(true)
                    .ToList();
            attributes.AddRange(
                targetMethod.GetCustomAttributes<
                    MethodInterceptionBaseAttribute
                >(true)
            );
            //attributes.Add(
            //    new ExceptionLogAspect(typeof(DatabaseLogger))
            //);
            var result = attributes
                // .GroupBy(x => x.GetType())
                //.Select(x => x.First())
                .OrderBy(x => x.Priority)
                .Cast<IInterceptor>()
                .ToArray();
//            throw new Exception(
//    "INTERCEPTOR SAYISI = " + result.Length +
//    " / " +
//    string.Join(", ", result.Select(x => x.GetType().FullName))
//);
            return result;
        }
    }
}