using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace EmployeePlyaroll
{
    class Details
    {
        static void Main(string[] args)
        {
             string connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=payroll_service;Trusted_Connection=True;";

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {              
                sqlConnection.Open();
                using(SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = sqlConnection;
                    cmd.CommandText = "SELECT * FROM Employee_Payroll";

                    SqlDataReader dr = cmd.ExecuteReader();
                    while(dr.Read())
                    {
                        string firstname = dr["First_Name"].ToString();
                        string lastname = dr["Last_Name"].ToString();
                        string salary = dr["Salary"].ToString();
                        string startdate = dr["StartDate"].ToString();
                        string gender = dr["Gender"].ToString();
                        string basicpay = dr["Basic_Pay"].ToString();
                        Console.WriteLine(firstname + " " + lastname+ " "+ salary +" "+startdate+" "+gender);
                    } 
                    dr.Close();
                }            
            }
            Console.ReadKey();
        }
    }
}