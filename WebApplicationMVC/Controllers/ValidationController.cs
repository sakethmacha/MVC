using Microsoft.AspNetCore.Mvc;
using WebApplicationMVC.Interfaces.Interfaces;
using WebApplicationMVC.Models.Models;
namespace WebApplicationMVC.Controllers
{
    public class ValidationController : Controller
    {
        private readonly IProductRepository _repo;
        public ValidationController(IProductRepository repo)
        {
            _repo = repo;
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Student model)
        {
            if (!ModelState.IsValid)
            {
                // Validation failed → return the same view with errors
                return View(model);
            }
            return RedirectToAction("Display");
        }
        [HttpGet]
        public IActionResult Display()
        {
            return View();
        }
    }
}
