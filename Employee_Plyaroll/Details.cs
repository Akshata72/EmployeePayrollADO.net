using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayrollADO
{
    public class Employee
    {
        public int ID { get; set; }
        public string Firstname { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public double BasicPay { get; set; }
        public double Deducations { get; set; }
        public double TaxablePay { get; set; }
        public double IncomeTax { get; set; }
        public double NetPay { get; set; }
    }
}
