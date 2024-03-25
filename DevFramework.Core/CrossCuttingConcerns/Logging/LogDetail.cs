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
    public class LogDetail
    {
        public string MethodFullName { get; set; }
        public string MethodName { get; set; }
        public List<LogParameter> MethodParameters { get; set; }
    }
}