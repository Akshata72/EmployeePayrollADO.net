using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayrollADO
{
    public class EmployeePayrollException :Exception
    {
        ExceptionType exceptionType;
        public enum ExceptionType
        {
            CONNECTION_FAILED,SALARYNOTUPDATE
        }
        public EmployeePayrollException (ExceptionType exceptionType,string message):base(message)
        {
            this.exceptionType = exceptionType;
        }
    }
}
