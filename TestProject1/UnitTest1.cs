using NUnit.Framework;
using System;

namespace EmployeePayrollADO
{
    public class Tests
    {
        EmployeePlayroll employeePlayroll;
        [SetUp]
        public void Setup()
        {
            employeePlayroll = new EmployeePlayroll();
        }
        /// <summary>
        /// UC2 - Get the all Employee Payroll Data
        /// </summary>
        [Test]
        public void Get_AllEmployeePayrollData()
        {
            var actual = employeePlayroll.GetAllEmployeePayrollData();
            Assert.AreEqual(5, actual.Count);
        }
        /// <summary>
        /// UC 3 - Update the Salary of Emplyoee
        /// </summary>
        [Test]
        public void UpdateEmployeeSalary_ShouldReturn_True_AfterUpdate()
        {
            bool expected = true;
            Employee empPayroll = new Employee();
            empPayroll.ID = 1;
            empPayroll.Firstname = "Akshata";
            empPayroll.BasicPay = 20000;
            empPayroll.Deducations = 10000;
            empPayroll.TaxablePay = 7000;
            empPayroll.IncomeTax = 5000;
            empPayroll.NetPay = 2978000;
            bool result = employeePlayroll.UpdateEmployeeSalary(empPayroll);
            Assert.AreEqual(expected, result);
        }
    }
}