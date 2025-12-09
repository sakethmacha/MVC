using Microsoft.AspNetCore.Mvc;
using WebApplicationMVC.Interfaces.Interfaces;

namespace WebApplicationMVC.ViewComponents
{
    public class RecentEmployeesViewComponent : ViewComponent
    {
        private readonly IEmployeeService EmployeeService;

        public RecentEmployeesViewComponent(IEmployeeService service)
        {
            EmployeeService = service;
        }

        public async Task<IViewComponentResult> InvokeAsync(int count = 2)
        {
            var employees = (await EmployeeService.GetAllAsync())
                .OrderByDescending(e => e.CreatedDate)
                .Take(count)
                .ToList();

            return View(employees);
        }
    }
}
