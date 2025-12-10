using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplicationMVC.Interfaces.Interfaces;
using WebApplicationMVC.Models.Models;

namespace WebApplicationMVC.Services.Services
{
    public class EmployeeValidationService : IEmployeeValidationService
    {
        private readonly ApplicationDbContext DbContext;

        public EmployeeValidationService(ApplicationDbContext db)
        {
            DbContext = db;
        }

        public bool EmailExists(string email)
        {
            return DbContext.Employees.Any(e => e.Email == email && !e.IsDeleted);
        }
        public bool PhoneExists(string phone)
        {
            return DbContext.Employees.Any(e => e.Phone == phone && !e.IsDeleted);
        }
    }

}
