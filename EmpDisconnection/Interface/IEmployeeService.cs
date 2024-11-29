using EmpDisconnection.Dtos;

namespace EmpDisconnection.Interface
{
    public interface IEmployeeService
    {
        Task<List<EmployeeDtos>> GetAllEmployeeDetails();
        Task<EmployeeDtos> GetEmployeeDetailsById(int empid);
        Task<bool> AddEmployeeDetails(EmployeeDtos employeedetail);
        Task<bool> UpdateEmployeeDetails(EmployeeDtos employeedetail);
        Task<bool> DeleteEmployeeDetailsById(int empid);
    }
}
