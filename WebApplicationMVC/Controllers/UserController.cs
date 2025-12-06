using Microsoft.AspNetCore.Mvc;
using WebApplicationMVC.ViewModels;
namespace WebApplicationMVC.Controllers
{
    public class UserController:Controller
    {
        [HttpGet]
        public IActionResult Display()
        {
            ProductViewModel product = new ProductViewModel
            {
                Name = "Saketh",
                Age = 25,
                Email = "saketh@example.com"
            };
            return View(product);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(ProductViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            return Content($"Name: {model.Name}, Age: {model.Age}, Email: {model.Email}");
        }
    }
}
