using Castle.DynamicProxy;
using DevFramework.Core.CrossCuttingConcerns.Logging;
using DevFramework.Core.CrossCuttingConcerns.Logging.Log4Net;
using DevFramework.Core.Utilities.Interceptors;
using DevFramework.Core.Utilities.Messages;
using PostSharp.Aspects;
using PostSharp.Constraints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Core.Aspects.Postsharp.ExceptionAspects
{
    [Serializable]
    public class ExceptionLogAspect:OnExceptionAspect
    {
        [NonSerialized]
        private LoggerServiceBase _loggerServiceBase;
        private Type _loggerType;
        public ExceptionLogAspect(Type loggerType=null)
        {
                       _loggerType = loggerType;
        }
        public override void RuntimeInitialize(MethodBase method)
        {
            if(_loggerType!=null)
            {
                if (_loggerType.BaseType != typeof(LoggerServiceBase))
                    throw new Exception("Wrong Logger Type");
            }
        }
    }
}//
    /*public class ExceptionLogAspect:MethodInterception
    {
        private LoggerServiceBase _loggerServiceBase;
        public ExceptionLogAspect(Type loggerService)
        {
            if (loggerService.BaseType != typeof(LoggerServiceBase))
            {
                throw new System.Exception(AspectMessages.WrongLoggerType);
            }
            _loggerServiceBase = (LoggerServiceBase)Activator.CreateInstance(loggerService);
        }
            protected override void OnException(IInvocation invocation,System.Exception e)
            {
            LogDetailWithException logDetailWithException = GetLogDetail(invocation);
            logDetailWithException.ExceptionMessage = e.Message;
            _loggerServiceBase.Error(logDetailWithException);
            }
          private LogDetailWithException GetLogDetail(IInvocation invocation)
          {
                var logParameters=new List<LogParameter>();
            for(int i=0;i<invocation.Arguments.Length;i++)
            {
                logParameters.Add(new LogParameter
                {
                    MethodParameterName = invocation.GetConcreteMethod().GetParameters()[i].Name,
                    MethodParameterValue = invocation.Arguments[i],
                    MethodParameterType = invocation.Arguments[i].GetType().Name
                });
            }
            var logDetailWithException = new LogDetailWithException
            {
                MethodName=invocation.Method.Name,
                LogParameters = logParameters
            };
            return logDetailWithException;
          }
      }
}*/