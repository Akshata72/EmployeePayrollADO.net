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
                        Console.WriteLine(empPayroll.ID + "," + empPayroll.Firstname + "," + empPayroll.LastName + "," + empPayroll.Gender + "," + empPayroll.BasicPay + "," + empPayroll.Deducations + "," + empPayroll.TaxablePay + "," + empPayroll.IncomeTax + "," + empPayroll.NetPay);
                    }
                }
                sqlconnection.Close();
            }
            return empPayrollList;
        }
        public bool UpdateEmployeeSalary(Employee empPayroll)
        {
                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        SqlCommand command = new SqlCommand("[dbo].[UpdateEmplyoeeSalary]", connection);
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@ID", empPayroll.ID);
                        command.Parameters.AddWithValue("@First_Name", empPayroll.Firstname);
                        command.Parameters.AddWithValue("@Basic_Pay", empPayroll.BasicPay);
                        command.Parameters.AddWithValue("@Deduction", empPayroll.Deducations);
                        command.Parameters.AddWithValue("@Taxable_Pay", empPayroll.TaxablePay);
                        command.Parameters.AddWithValue("@Income_Tax", empPayroll.IncomeTax);
                        command.Parameters.AddWithValue("@Net_Pay", empPayroll.NetPay);
                        connection.Open();
                        var result = command.ExecuteNonQuery();
                        connection.Close();
                        if (result != 0)
                        {
                            return true;
                        }
                        return false;
                    }
                }
                catch (Exception)
                {
                  throw new EmployeePayrollException(EmployeePayrollException.ExceptionType.SALARYNOTUPDATE, "Emplyoee Salary Not Updated");
                  return false;
                }
        }
        public static Employee InsertEmployeeData(Employee employee)
        {
            string spName = "dbo.[AddingEmployeeDetails]";
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                using (connection)
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(spName, connection);

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@First_Name", employee.Firstname);
                    cmd.Parameters.AddWithValue("@Gender", employee.Gender);
                    //cmd.Parameters.AddWithValue("@StartDate", employee.StartDate);
                    cmd.Parameters.AddWithValue("@Basic_Pay", employee.BasicPay);
                    //0

                    cmd.ExecuteNonQuery();
                    connection.Close();


                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return employee;
        }
    }
}