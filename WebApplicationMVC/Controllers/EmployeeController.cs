using Microsoft.AspNetCore.Mvc;
using WebApplicationMVC.Interfaces.Interfaces;
using WebApplicationMVC.ViewModels.ViewModels;

namespace WebApplicationMVC.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService EmployeeService;

        public EmployeeController(IEmployeeService employeeservice)
        {
            EmployeeService = employeeservice;
        }

        // List active employees
        public async Task<IActionResult> Index()
        {
            return View(await EmployeeService.GetAllAsync());
        }

        // List deleted employees
        public async Task<IActionResult> Deleted()
        {
            return View(await EmployeeService.GetDeletedAsync());
        }

        // Employee details
        public async Task<IActionResult> Details(int id)
        {
            var emp = await EmployeeService.GetByIdAsync(id);
            if (emp == null)
                return NotFound();

            return View(emp);
        }

        // GET: Create form
        public IActionResult Create()
        {
            return View();
        }

        // POST: Create employee
        [HttpPost]
        public async Task<IActionResult> Create(EmployeeViewModel vm)
        {
            if (!ModelState.IsValid)
                return View(vm);

            await EmployeeService.AddAsync(vm);

            return RedirectToAction("Success");
        }

        // GET: Edit form
        public async Task<IActionResult> Edit(int id)
        {
            var emp = await EmployeeService.GetByIdAsync(id);
            if (emp == null)
                return NotFound();

            var vm = new EmployeeViewModel
            {
                EmployeeId = emp.EmployeeId,
                FirstName = emp.FirstName,
                LastName = emp.LastName,
                Email = emp.Email,
                Phone = emp.Phone,
                Age = emp.Age,
                DOB = emp.DOB,
                Address = emp.Address,
                Salary = emp.Salary,
                Gender = emp.Gender,
                IsMarried = emp.IsMarried,
                Department = emp.Department
            };

            return View(vm);
        }

        // POST: Update employee
        [HttpPost]
        public async Task<IActionResult> Edit(EmployeeViewModel vm)
        {
            if (!ModelState.IsValid)
                return View(vm);

            await EmployeeService.UpdateAsync(vm);

            return RedirectToAction("Index");
        }

        public IActionResult Success()
        {
            return View();
        }

        // Soft delete employee
        public async Task<IActionResult> Delete(int id)
        {
            await EmployeeService.SoftDeleteAsync(id);
            return RedirectToAction("Index");
        }

        // Restore soft-deleted employee
        public async Task<IActionResult> Restore(int id)
        {
            await EmployeeService.RestoreAsync(id);
            return RedirectToAction("Index");
        }
    }
}
