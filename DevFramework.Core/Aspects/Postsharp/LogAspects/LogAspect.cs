using Castle.DynamicProxy;
using DevFramework.Core.CrossCuttingConcerns.Logging;
using DevFramework.Core.CrossCuttingConcerns.Logging.Log4Net;
using DevFramework.Core.Utilities.Interceptors;
using DevFramework.Core.Utilities.Messages;
using PostSharp.Aspects;
using PostSharp.Extensibility;
using PostSharp.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
/*
 41.Adım
*/
namespace DevFramework.Core.Aspects.Postsharp.LogAspects
{
    //[PSerializable]
    [MulticastAttributeUsage(MulticastTargets.Method, TargetMemberAttributes = MulticastAttributes.Instance)]
    public class LogAspect:/*OnMethodBoundaryAspect*/MethodInterception
    {
        Type _loggerService;
        LoggerServiceBase _loggerServiceBase;
        public LogAspect(Type loggerService)
        {
            if(loggerService.BaseType!=typeof(LoggerServiceBase))
            {
                throw new System.Exception(AspectMessages.WrongLoggerType);
            }
            _loggerServiceBase=(LoggerServiceBase)Activator.CreateInstance(loggerService);
            //_loggerService=loggerService;
        }
        protected override void OnBefore(IInvocation invocation)
        {
            //throw new Exception("LogAspect çalıştı!");
            _loggerServiceBase.Info(GetLogDetail(invocation));
        }
        //public override void RuntimeInitialize(MethodBase method)
        //{
        //    _loggerServiceBase =
        //        (LoggerServiceBase)Activator.CreateInstance(_loggerService);

        //    base.RuntimeInitialize(method);
        //}
        //public override void OnEntry(MethodExecutionArgs args)
        //{
        //    _loggerServiceBase.Info(GetLogDetail(args));
        //}
        private LogDetail GetLogDetail(IInvocation invocation)
        {
            var logParameters=new List<LogParameter>();
            for(int i = 0; i < invocation.Arguments.Length; i++)
            {
                logParameters.Add(new LogParameter
                {
                    MethodParameterName = invocation.GetConcreteMethod().GetParameters()[i].Name,
                    MethodParameterValue = invocation.Arguments[i],
                    MethodParameterType = invocation.Arguments[i].GetType().Name
                });
            }
            var logDetail = new LogDetail
            {
                MethodName = invocation.Method.Name,
                LogParameters = logParameters
            };
            return logDetail;
        }
    }
}