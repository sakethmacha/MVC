using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplicationMVC.Interfaces.Interfaces
{
    public interface IEmployeeValidationService
    {
        bool EmailExists(string email);
        bool PhoneExists(string phone);
    }
}
