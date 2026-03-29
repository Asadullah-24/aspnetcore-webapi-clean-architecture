using CleanArchitecture.Core.Entities;

namespace CleanArchitecture.Core.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<EmployeeEntity>> GetEmployees();
        Task<EmployeeEntity> GetEmployeeByIdAsync(int Id);
        Task<EmployeeEntity> AddEmployeeByAsync(EmployeeEntity emp);
        Task<EmployeeEntity> UpdateEmployeeByAsync(int empId, EmployeeEntity emp);
        Task<bool> DeleteEmployeeByAsync(int empId);
    }
}
