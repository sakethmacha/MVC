using Microsoft.EntityFrameworkCore;
using WebApplicationMVC.Interfaces.Interfaces;
using WebApplicationMVC.Models.Models;
using WebApplicationMVC.ViewModels.ViewModels;
namespace WebApplicationMVC.Services.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly ApplicationDbContext DbContext;

        public EmployeeService(ApplicationDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public async Task<List<Employee>> GetAllAsync()
        {
            return await DbContext.Employees
                .Where(e => !e.IsDeleted)
                .ToListAsync();
        }

        public async Task<List<Employee>> GetDeletedAsync()
        {
            return await DbContext.Employees
                .Where(e => e.IsDeleted)
                .ToListAsync();
        }

        public async Task<Employee?> GetByIdAsync(int id)
        {
            return await DbContext.Employees
                .FirstOrDefaultAsync(x => x.EmployeeId == id);
        }

        public async Task AddAsync(EmployeeViewModel employeeViewModel)
        {
            var employee = new Employee
            {
                FirstName = employeeViewModel.FirstName,
                LastName = employeeViewModel.LastName,
                Email = employeeViewModel.Email,
                Phone = employeeViewModel.Phone,
                Age = employeeViewModel.Age,
                DOB = employeeViewModel.DOB,
                Address = employeeViewModel.Address,
                Password = employeeViewModel.Password,
                ConfirmPassword = employeeViewModel.Password,
                Salary = employeeViewModel.Salary,
                Gender = employeeViewModel.Gender,
                IsMarried = employeeViewModel.IsMarried,
                Department = employeeViewModel.Department,
                CreatedDate = DateTime.Now,
                UpdatedDate = null,
                IsDeleted = false
            };

            await DbContext.Employees.AddAsync(employee);
            await DbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(EmployeeViewModel employeeViewModel)
        {
            var employee = await DbContext.Employees.FindAsync(employeeViewModel.EmployeeId);
            if (employee == null)
                return;

            employee.FirstName = employeeViewModel.FirstName;
            employee.LastName = employeeViewModel.LastName;
            employee.Email = employeeViewModel.Email;
            employee.Phone = employeeViewModel.Phone;
            employee.Age = employeeViewModel.Age;
            employee.DOB = employeeViewModel.DOB;
            employee.Address = employeeViewModel.Address;
            employee.Salary = employeeViewModel.Salary;
            employee.Gender = employeeViewModel.Gender;
            employee.IsMarried = employeeViewModel.IsMarried;
            employee.Department = employeeViewModel.Department;
            employee.UpdatedDate = DateTime.Now;

            DbContext.Employees.Update(employee);
            await DbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var employee = await GetByIdAsync(id);
            if (employee == null)
                return;

            employee.IsDeleted = true;
            await DbContext.SaveChangesAsync();
        }

        public async Task RestoreAsync(int id)
        {
            var employee = await GetByIdAsync(id);
            if (employee == null)
                return;

            employee.IsDeleted = false;
            await DbContext.SaveChangesAsync();
        }
    }
}
