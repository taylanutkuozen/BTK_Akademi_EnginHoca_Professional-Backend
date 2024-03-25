using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
35.Adım 
*/
namespace DevFramework.Core.CrossCuttingConcerns.Logging
{
    public class LogParameter
    {
        public string MethodParameterName { get; set; }
        public string MethodParameterType { get; set; }
        public object MethodParameterValue { get; set; }
    }
}