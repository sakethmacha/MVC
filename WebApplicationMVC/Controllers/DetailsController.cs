using Microsoft.AspNetCore.Mvc;
using WebApplicationMVC.Interfaces.Interfaces;
using WebApplicationMVC.Models.Models;
using WebApplicationMVC.ViewModels;
namespace WebApplicationMVC.Controllers
{
    public class DetailsController : Controller
    {
        private readonly IProductRepository Service;
        private readonly IProductRepository Service2;

        public DetailsController(IProductRepository service, IProductRepository service2)
        {
            Service = service;
            Service2 = service2;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Details details)
        {
            Service.Add(details);
            //_repo2.Add(details);
            return RedirectToAction("Print", new { id = details.DetailsId });
        }
        [HttpGet]
        public IActionResult Print(int id)
        {
            var vm = new CreateViewModel
            {
                InsertedItem = Service.GetById(id),
                AllRecords = Service.GetAll()
            };

            return View(vm);
        }

    }
}
