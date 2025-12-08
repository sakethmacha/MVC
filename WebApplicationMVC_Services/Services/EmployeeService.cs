using Microsoft.EntityFrameworkCore;
using WebApplicationMVC.Interfaces.Interfaces;
using WebApplicationMVC.Models.Models;

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

        public async Task AddAsync(Employee employee)
        {
            await DbContext.Employees.AddAsync(employee);
            await DbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Employee employee)
        {
            DbContext.Employees.Update(employee);
            await DbContext.SaveChangesAsync();
        }

        public async Task SoftDeleteAsync(int id)
        {
            var emp = await GetByIdAsync(id);
            if (emp == null)
            {
                return;
            }
            emp.IsDeleted = true;
            await DbContext.SaveChangesAsync();
        }

        public async Task RestoreAsync(int id)
        {
            var emp = await GetByIdAsync(id);
            if (emp == null)
            {
                return;
            }
            emp.IsDeleted = false;
            await DbContext.SaveChangesAsync();
        }
    }
}
