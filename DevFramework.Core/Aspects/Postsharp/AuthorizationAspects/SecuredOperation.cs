using PostSharp.Aspects;
using PostSharp.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
namespace DevFramework.Core.Aspects.Postsharp.AuthorizationAspects
{
    [PSerializable]
    public class SecuredOperation:OnMethodBoundaryAspect
    {
        public string Roles
        {
            get;
            set;
        }
        public override void OnEntry(MethodExecutionArgs args)
        {
            string[] roles = Roles.Split(',');
            bool isAuthorized = false;
            for (int i=0;i<roles.Length;i++)
            {
                if (System.Threading.Thread.CurrentPrincipal.IsInRole(roles[i]))//CurrentPrincipal mevcut kullanicimizi ve bu kullaniciya dair bilgiler tutulur. Role bazli guvenlik sistemlerde kullanilir. Session Role-Based Security icin degildir.
                {
                    isAuthorized = true;
                }
            }
            if (isAuthorized == false)
            {
                throw new SecurityException("You are not authorized!");
            }
        }
    }
}
