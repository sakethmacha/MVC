
using Microsoft.AspNetCore.Mvc;
using WebApplicationMVC.ViewModels;

namespace WebApplicationMVC.Controllers
{
    [Route("product")]
    public class ProductController:Controller
    {
        [HttpGet("ContactForm")]
        public IActionResult ContactForm()
        {
            return View();
        }
        [HttpPost("Contact")] 
        public IActionResult Contact(string message)
        {
            return Content("Message received: " + message);
        }
    }
}
