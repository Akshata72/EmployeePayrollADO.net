using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace EmployeePayrollADO
{
    class Program
    {
        static void Main(string[] args)
        {
            int Option = 0;
            EmployeePlayroll employeePlayroll = new EmployeePlayroll();
            Employee empPayroll = new Employee();
            do
            {
                Console.WriteLine("\nWelcome in Employee Service Payroll");
                Console.WriteLine("Enter 1 for Establish connection");
                Console.WriteLine("Enter 2 for Close Connection");
                Console.WriteLine("Enter 3 for Get all Employee payroll data ");
                Console.WriteLine("Enter 0 for Exit");
                try
                {
                    Option = int.Parse(Console.ReadLine());
                    switch (Option)
                    {
                        case 1:
                            employeePlayroll.EstablishConnection();
                            Console.WriteLine("Establish connection succsefully");
                            break;
                        case 2:
                            employeePlayroll.CloseConnection();
                            break;
                        case 3:
                            employeePlayroll.GetAllEmployeePayrollData();
                            break;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Choose Correct Option");
                }
            }
            while (Option != 0);
        }
    }
}