using Microsoft.EntityFrameworkCore;
using WebApplicationMVC.Interfaces.Interfaces;
using WebApplicationMVC.Models.Models;
using WebApplicationMVC.ViewModels.ViewModels;
namespace WebApplicationMVC.Services.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly ApplicationDbContext DbContext;

        public EmployeeService(ApplicationDbContext context)
        {
            DbContext = context;
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

        public async Task AddAsync(EmployeeViewModel vm)
        {
            var employee = new Employee
            {
                FirstName = vm.FirstName,
                LastName = vm.LastName,
                Email = vm.Email,
                Phone = vm.Phone,
                Age = vm.Age,
                DOB = vm.DOB,
                Address = vm.Address,
                Password = vm.Password,
                Salary = vm.Salary,
                Gender = vm.Gender,
                IsMarried = vm.IsMarried,
                Department = vm.Department,
                CreatedDate = DateTime.Now,
                UpdatedDate = null,
                IsDeleted = false
            };

            await DbContext.Employees.AddAsync(employee);
            await DbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(EmployeeViewModel vm)
        {
            var employee = await DbContext.Employees.FindAsync(vm.EmployeeId);
            if (employee == null)
                return;

            employee.FirstName = vm.FirstName;
            employee.LastName = vm.LastName;
            employee.Email = vm.Email;
            employee.Phone = vm.Phone;
            employee.Age = vm.Age;
            employee.DOB = vm.DOB;
            employee.Address = vm.Address;
            employee.Salary = vm.Salary;
            employee.Gender = vm.Gender;
            employee.IsMarried = vm.IsMarried;
            employee.Department = vm.Department;
            employee.UpdatedDate = DateTime.Now;

            DbContext.Employees.Update(employee);
            await DbContext.SaveChangesAsync();
        }

        public async Task SoftDeleteAsync(int id)
        {
            var emp = await GetByIdAsync(id);
            if (emp == null)
                return;

            emp.IsDeleted = true;
            await DbContext.SaveChangesAsync();
        }

        public async Task RestoreAsync(int id)
        {
            var emp = await GetByIdAsync(id);
            if (emp == null)
                return;

            emp.IsDeleted = false;
            await DbContext.SaveChangesAsync();
        }
    }
}
