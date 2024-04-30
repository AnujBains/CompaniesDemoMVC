using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using CompaniesDemoMVC.Models;

namespace CompaniesDemoMVC.Models
{
    public class CompanyRepository
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;

        public IEnumerable<Company> GetAllEmployee()
        {
            List<Company> employeeList = new List<Company>();

            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "Select * from Company";
                SqlCommand cmd = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Company company = new Company()
                    {
                        EmployeeId = Convert.ToInt32(reader["EmployeeID"]),
                        Name = reader["Name"].ToString(),
                        Designation = reader["Designation"].ToString(),
                        Salary = Convert.ToInt32(reader["Salary"])
                    };
                    employeeList.Add(company);
                }
            }
            return employeeList;    
        }
        public void AddCompany(Company company)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spAddCompany", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EmployeeID", company.EmployeeId);
                cmd.Parameters.AddWithValue("@Name", company.Name);
                cmd.Parameters.AddWithValue("@Designation", company.Designation);
                cmd.Parameters.AddWithValue("@Salary", company.Salary);
                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public bool IsEmployeeIdExists(int employeeId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string qurey = "select count(*) from company where EmployeeId = @EmployeeId";
                SqlCommand cmd = new SqlCommand(qurey, connection);
                cmd.Parameters.AddWithValue("@EmployeeId", employeeId);
                connection.Open();
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }
        public void UpdateCompany(Company company)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spUpdateCompany", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EmployeeID", company.EmployeeId);
                cmd.Parameters.AddWithValue("@Name", company.Name);
                cmd.Parameters.AddWithValue("@Designation", company.Designation);
                cmd.Parameters.AddWithValue("@Salary", company.Salary);
                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteCompany(int employeeId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string qurey = "delete from company where EmployeeId = @employeeId";
                SqlCommand cmd = new SqlCommand(qurey, connection);
                cmd.Parameters.AddWithValue("@EmployeeId", employeeId);
                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }

    }
}