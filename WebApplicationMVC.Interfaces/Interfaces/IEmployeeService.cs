using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplicationMVC.Models.Models;

namespace WebApplicationMVC.Interfaces.Interfaces
{
    public interface IEmployeeService
    {
        Task<List<Employee>> GetAllAsync();
        Task<List<Employee>> GetDeletedAsync();
        Task<Employee?> GetByIdAsync(int id);
        Task AddAsync(Employee employee);
        Task UpdateAsync(Employee employee);
        Task SoftDeleteAsync(int id);
        Task RestoreAsync(int id);
    }

}
