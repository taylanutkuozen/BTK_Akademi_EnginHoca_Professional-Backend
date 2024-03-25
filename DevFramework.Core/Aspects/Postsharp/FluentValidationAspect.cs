using DevFramework.Core.CrossCuttingConcerns.Validation.FluentValidation;
using FluentValidation;
using PostSharp.Aspects;
using PostSharp.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//25.Adım
namespace DevFramework.Core.Aspects.Postsharp
{
    [PSerializable]
    public class FluentValidationAspect : OnMethodBoundaryAspect
    {
        Type _validatorType;
        public FluentValidationAspect(Type validatorType)
        {
            _validatorType = _validatorType;
        }
        public override void OnEntry(MethodExecutionArgs args) //Methodun girişinde aspect devreye girecektir.
        {
            var validator =(IValidator)Activator.CreateInstance(_validatorType);
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];//Birinci generic argümanın Type'ı
            var entities = args.Arguments.Where(t => t.GetType() == entityType);//args çalıştırılan method ile ilgili bilgi almamızı sağlar. Where koşulunda çalışılan methodun parametrelerini gezip type'ı product olanları yakaladık.
            foreach (var entity in entities)
            {
                ValidatorTool.FluentValidate(validator, entity);
            }
        }
    }
}