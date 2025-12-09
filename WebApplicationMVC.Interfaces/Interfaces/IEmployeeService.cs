
using WebApplicationMVC.Models.Models;
using WebApplicationMVC.ViewModels.ViewModels;
    namespace WebApplicationMVC.Interfaces.Interfaces
    {
        public interface IEmployeeService
        {
            Task<List<Employee>> GetAllAsync();
            Task<List<Employee>> GetDeletedAsync();
            Task<Employee?> GetByIdAsync(int id);

            Task AddAsync(EmployeeViewModel vm);
            Task UpdateAsync(EmployeeViewModel vm);

            Task SoftDeleteAsync(int id);
            Task RestoreAsync(int id);
        }
    }
