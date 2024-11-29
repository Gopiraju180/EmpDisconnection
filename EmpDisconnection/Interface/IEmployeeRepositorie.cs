using EmpDisconnection.Entities;

namespace EmpDisconnection.Interface
{
    public interface IEmployeeRepositorie
    {
        Task<List<Employee>> GetAllEmployeeDetails();
        Task<Employee>GetEmployeeDetailsById(int empid);
        Task<bool> AddEmployeeDetails(Employee employeedetail);
        Task<bool> UpdateEmployeeDetails(Employee employeedetail);
        Task<bool> DeleteEmployeeDetailsById(int empid);
    }
}
