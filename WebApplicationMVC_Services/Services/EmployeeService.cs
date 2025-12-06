using Microsoft.EntityFrameworkCore;
using WebApplicationMVC.Interfaces.Interfaces;
using WebApplicationMVC.Models.Models;

namespace WebApplicationMVC.Services.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly ApplicationDbContext _context;

        public EmployeeService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Employee>> GetAllAsync()
        {
            return await _context.Employees
                .Where(e => !e.IsDeleted)
                .ToListAsync();
        }

        public async Task<List<Employee>> GetDeletedAsync()
        {
            return await _context.Employees
                .Where(e => e.IsDeleted)
                .ToListAsync();
        }

        public async Task<Employee?> GetByIdAsync(int id)
        {
            return await _context.Employees
                .FirstOrDefaultAsync(x => x.EmployeeId == id);
        }

        public async Task AddAsync(Employee employee)
        {
            await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Employee employee)
        {
            _context.Employees.Update(employee);
            await _context.SaveChangesAsync();
        }

        public async Task SoftDeleteAsync(int id)
        {
            var emp = await GetByIdAsync(id);
            if (emp == null) return;

            emp.IsDeleted = true;
            await _context.SaveChangesAsync();
        }

        public async Task RestoreAsync(int id)
        {
            var emp = await GetByIdAsync(id);
            if (emp == null) return;

            emp.IsDeleted = false;
            await _context.SaveChangesAsync();
        }
    }
}
