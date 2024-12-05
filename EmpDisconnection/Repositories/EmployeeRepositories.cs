using EmpDisconnection.Entities;
using EmpDisconnection.Interface;
using EmpDisconnection.utils;
using Microsoft.Data.SqlClient;
using System.Data;

namespace EmpDisconnection.Repositories
{
    public class EmployeeRepositories : IEmployeeRepositorie
    {
        //Below Connection is HardCode in our Project, So RealTime not recommended in this way
        //string connectionString = "data source=DESKTOP-LNEME22;integrated security=yes;Encrypt=True;TrustServerCertificate=True;initial catalog=hotelmanagement";
        private readonly IConnectionFactory _connectionFactory;
        public EmployeeRepositories(IConnectionFactory connectionFactory)
        {
             _connectionFactory = connectionFactory;
        }
        public async Task<bool> AddEmployeeDetails(Employee employeedetail)
        {
           // var connStr = Convert.ToString(_config.GetSection(ConnectionStringName.DBHotelConnectionStringName).Value);
            using (SqlConnection con = _connectionFactory.hotelmanagementsqlConnectionString())
            {
                SqlCommand cmd = new SqlCommand(StoredProcedureNames.AddEmployee, con);
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@empid", employeedetail.empid);
                cmd.Parameters.AddWithValue(StoredProcedureParameters.EmpName, employeedetail.empname);
                cmd.Parameters.AddWithValue(StoredProcedureParameters.EmpSalary, employeedetail.empsalary);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, "Employee");
            }
            return true;
        }


        public async Task<bool> DeleteEmployeeDetailsById(int empid)
        {
            //var connStr = Convert.ToString(_config.GetSection(ConnectionStringName.DBHotelConnectionStringName).Value);

            using (SqlConnection con =_connectionFactory.hotelmanagementsqlConnectionString())
            {
                SqlCommand cmd = new SqlCommand(StoredProcedureNames.DeleteEmployee, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue(StoredProcedureParameters.EmpId, empid);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, "Employee");
            }
            return true;
        }

        public async Task<List<Employee>> GetAllEmployeeDetails()
        {
            //var connStr = Convert.ToString(_config.GetSection(ConnectionStringName.DBHotelConnectionStringName).Value);

            List<Employee> lstemp = new List<Employee>();//create empty list
            using (SqlConnection con = _connectionFactory.hotelmanagementsqlConnectionString())
            {
                SqlCommand cmd = new SqlCommand(StoredProcedureNames.GetEmployee, con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();//To store the data at ado.net side in table format we use dataset.
                dataAdapter.Fill(ds, "Employee");
                foreach (DataRow row in ds.Tables["Employee"].Rows)
                {
                    Employee emp = new Employee();
                    emp.empid = Convert.ToInt16(row["empid"]);
                    emp.empname = Convert.ToString(row["empname"]);
                    emp.empsalary = Convert.ToInt32(row["empsalary"]);
                    lstemp.Add(emp);
                }
                return lstemp;
            }
        }

        public async Task<Employee> GetEmployeeDetailsById(int empid)
        {
            //var connStr = Convert.ToString(_config.GetSection(ConnectionStringName.DBHotelConnectionStringName).Value);
            Employee emp = new Employee();
            using (SqlConnection con = _connectionFactory.hotelmanagementsqlConnectionString())
            {
                SqlCommand cmd = new SqlCommand(StoredProcedureNames.GetEmployeeByEmpid, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue(StoredProcedureParameters.EmpId, empid);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, "Employee");
                foreach (DataRow row in ds.Tables["Employee"].Rows)
                {
                    emp.empid = Convert.ToInt16(row["empid"]);
                    emp.empname = Convert.ToString(row["empname"]);
                    emp.empsalary = Convert.ToInt32(row["empsalary"]);
                }
            }
            return emp;
        }
        public async Task<bool> UpdateEmployeeDetails(Employee employeedetail)
        {
            //var connStr = Convert.ToString(_config.GetSection(ConnectionStringName.DBHotelConnectionStringName).Value);
            using (SqlConnection con = _connectionFactory.hotelmanagementsqlConnectionString())
            {
                SqlCommand cmd = new SqlCommand(StoredProcedureNames.UpdateEmployee, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue(StoredProcedureParameters.EmpId, employeedetail.empid);
                cmd.Parameters.AddWithValue(StoredProcedureParameters.EmpName, employeedetail.empname);
                cmd.Parameters.AddWithValue(StoredProcedureParameters.EmpSalary, employeedetail.empsalary);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, "Employee");

            }
            return true;
        }
    }
}
