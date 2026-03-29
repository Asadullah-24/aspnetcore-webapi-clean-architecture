using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Interfaces;
using CleanArchitecture.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.Repositories
{
    public class EmployeeRepository(AppDbContext dbContext) : IEmployeeRepository
    {
        public async Task<IEnumerable<EmployeeEntity>> GetEmployees()
        {
            return await dbContext.Employees.ToListAsync();
        }
        public async Task<EmployeeEntity> GetEmployeeByIdAsync(int Id)
        {
            return await dbContext.Employees.FirstOrDefaultAsync(x => x.Id == Id);
        }
        public async Task<EmployeeEntity> AddEmployeeByAsync(EmployeeEntity emp)
        {
            dbContext.Employees.Add(emp);
            await dbContext.SaveChangesAsync();
            return emp;
        }
        public async Task<EmployeeEntity> UpdateEmployeeByAsync(int empId, EmployeeEntity emp)
        {
            var employee = await dbContext.Employees.FirstOrDefaultAsync(x => x.Id == empId);
            if (employee is not null)
            {
                employee.Name = emp.Name;
                employee.Email = emp.Email;
                employee.Phone = emp.Phone;
                await dbContext.SaveChangesAsync();
                return employee;
            }
            return emp;

        }
        public async Task<bool> DeleteEmployeeByAsync(int empId)
        {
            var employee = await dbContext.Employees.FirstOrDefaultAsync(x => x.Id == empId);
            if (employee is not null)
            {
                dbContext.Employees.Remove(employee);
                return await dbContext.SaveChangesAsync() > 0;
            }
            return false;
        }
    }
}
