using Microsoft.AspNetCore.Mvc;
using WebApplicationMVC.Interfaces.Interfaces;
using WebApplicationMVC.Models.Models;

namespace WebApplicationMVC.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService Service;

        public EmployeeController(IEmployeeService service)
        {
            Service = service;
        }

        public async Task<IActionResult> Index()
        {
            return View(await Service.GetAllAsync());
        }

        public async Task<IActionResult> Deleted()
        {
            return View(await Service.GetDeletedAsync());
        }

        public async Task<IActionResult> Details(int id)
        {
            var emp = await Service.GetByIdAsync(id);
            if (emp == null)
            {
                return NotFound();
            }
            return View(emp);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return View(employee);
            }
            employee.CreatedDate = DateTime.Now;
            employee.UpdatedDate = null;

            await Service.AddAsync(employee);

            return RedirectToAction("Index");
        }


        public async Task<IActionResult> Edit(int id)
        {
            var emp = await Service.GetByIdAsync(id);
            if (emp == null)
            {
                return NotFound();
            }
            return View(emp);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return View(employee);
            }
            employee.UpdatedDate = DateTime.Now; // update time 

            await Service.UpdateAsync(employee);

            return RedirectToAction("Index");
        }


        public async Task<IActionResult> Delete(int id)
        {
            await Service.SoftDeleteAsync(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Restore(int id)
        {
            await Service.RestoreAsync(id);
            return RedirectToAction("Index");
        }

    }


}
