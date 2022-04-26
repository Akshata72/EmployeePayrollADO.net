using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayrollADO
{
    public class EmployeePlayroll
    {
        static string connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=payroll_service;Trusted_Connection=True;";
        static SqlConnection sqlconnection = new SqlConnection(connectionString);
        public void EstablishConnection()
        {
            if (sqlconnection != null && sqlconnection.State.Equals(ConnectionState.Closed))
            {
                try
                {
                    sqlconnection.Open();
                }
                catch (Exception)
                {
                    throw new EmployeePayrollException(EmployeePayrollException.ExceptionType.CONNECTION_FAILED, "connection failed");

                }
            }
        }
        public void CloseConnection()
        {
            if (sqlconnection != null && sqlconnection.State.Equals(ConnectionState.Open))
            {
                try
                {
                    sqlconnection.Close();
                }
                catch (Exception)
                {
                    throw new EmployeePayrollException(EmployeePayrollException.ExceptionType.CONNECTION_FAILED, "connection failed");
                }
            }
        }
        public List<Employee> GetAllEmployeePayrollData()
        {
            List<Employee> empPayrollList = new List<Employee>();
            Employee empPayroll = new Employee();
            SqlConnection sqlconnection = new SqlConnection(connectionString);
            string Spname = "GetAllEmployeePayrollData()";
            using (sqlconnection)
            {
                SqlCommand sqlCommand = new SqlCommand(Spname, sqlconnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlconnection.Open();
                SqlDataReader dr = sqlCommand.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        empPayroll.ID = dr.GetInt32(0);
                        empPayroll.Firstname = dr.GetString(1);
                        empPayroll.LastName = dr.GetString(2);
                        empPayroll.Gender = (dr.GetString(3));
                        empPayroll.BasicPay = dr.IsDBNull(8) ? 0 : dr.GetInt64(8);
                        empPayroll.Deducations = dr.IsDBNull(4) ? 0 : dr.GetInt64(4);
                        empPayroll.TaxablePay = dr.IsDBNull(5) ? 0 : dr.GetInt64(5);
                        empPayroll.IncomeTax = dr.IsDBNull(6) ? 0 : dr.GetInt64(6);
                        empPayroll.NetPay = dr.IsDBNull(7) ? 0 : dr.GetInt64(7);
                        empPayrollList.Add(empPayroll);
                        Console.WriteLine(empPayroll.ID + "," + empPayroll.Firstname +","+empPayroll.LastName+ "," + empPayroll.Gender + "," + empPayroll.BasicPay +  ","+ empPayroll.Deducations+"," + empPayroll.TaxablePay + "," + empPayroll.IncomeTax + "," + empPayroll.NetPay);
                    }
                }
                sqlconnection.Close();
            }
            return empPayrollList;
        }
    }
}