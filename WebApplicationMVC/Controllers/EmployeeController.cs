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
            var employee = await EmployeeService.GetByIdAsync(id);
            if (employee == null)
                return NotFound();

            return View(employee);
        }

        // GET: Create form
        public IActionResult Create()
        {
            return View();
        }

        // POST: Create employee
        [HttpPost]
        public async Task<IActionResult> Create(EmployeeViewModel employeeViewModel)
        {
            if (!ModelState.IsValid)
                return View(employeeViewModel);

            await EmployeeService.AddAsync(employeeViewModel);

            return RedirectToAction("Success");
        }

        // GET: Edit form
        public async Task<IActionResult> Edit(int id)
        {
            var employee = await EmployeeService.GetByIdAsync(id);
            if (employee == null)
                return NotFound();

            var employeeViewModel = new EmployeeViewModel
            {
                EmployeeId = employee.EmployeeId,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Email = employee.Email,
                Phone = employee.Phone,
                Age = employee.Age,
                DOB = employee.DOB,
                Address = employee.Address,
                Salary = employee.Salary,
                Gender = employee.Gender,
                IsMarried = employee.IsMarried,
                Department = employee.Department
            };

            return View(employeeViewModel);
        }

        // POST: Update employee
        [HttpPost]
        public async Task<IActionResult> Edit(EmployeeViewModel employeeViewModel)
        {
            if (!ModelState.IsValid)
                return View(employeeViewModel);

            await EmployeeService.UpdateAsync(employeeViewModel);

            return RedirectToAction("Index");
        }

        public IActionResult Success()
        {
            return View();
        }

        // Soft delete employee
        public async Task<IActionResult> Delete(int id)
        {
            await EmployeeService.DeleteAsync(id);
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
