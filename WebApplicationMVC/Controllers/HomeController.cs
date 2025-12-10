using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using WebApplicationMVC.Interfaces.Interfaces;
using WebApplicationMVC.Models;
using WebApplicationMVC.ViewModels;
using WebApplicationMVC.Filters;
namespace WebApplicationMVC.Controllers
{
    [Route("")]              // <--- Makes this controller respond to "/"
    [Route("home")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRequestService _requestIdService;
        private readonly IRequestService _requestIdService2;
        private readonly ICounterService _counterService;
        private readonly ICounterService _counterService2;
        public HomeController(
            IRequestService requestIdService,
            ICounterService counterService, ILogger<HomeController> logger, IRequestService requestIdService2, ICounterService counterService2)
        {
            _requestIdService = requestIdService;
            _counterService = counterService;
            _logger = logger;
            
            _requestIdService2 = requestIdService2;
            _counterService2 = counterService2;
          
        }
        [HttpGet("")]
        public IActionResult Index()
        {
            var vm = new ProductViewModel
            {
                Name = "Test Product",
                Email = "test@example.com",
                Age = 23
            };

            return View(vm);
        }

        
        [HttpGet("Privacy")]
        public IActionResult Privacy()
        {
            var vm = new ProductViewModel
            {
                Name = "Test Product",
                Email = "test@example.com",
                Age = 23
            };

            return View(vm);
        }
        [HttpGet("Abouts")]
        public IActionResult Abouts()
        {
            var model = new
            {
                // Transient (new instance each time)
                //Transient3 = _randomService.RandomServices(),
                //Transient4 = _randomService2.RandomServices(),
                // Scoped (same instance during one request)
                Transient3 = _requestIdService.RequestId,
                Transient4 = _requestIdService2.RequestId,

                Scoped1 = _requestIdService.RequestId,
                Scoped2 = _requestIdService2.RequestId,

                // Singleton (same instance forever)
                SingletonCounter1 = _counterService.GetCount(),
                SingletonCounter2 = _counterService2.GetCount()
            };

            return Json(model);
            //return View();
        }

        //[Authorize] // only logged-in users can see this
        //[TypeFilter(typeof(CustomAuthorizationFilter))]
        [CustomAuthorizationFilter]
        [HttpGet("SecretPage")]
        public IActionResult SecretPage()
        {
            return View();
        }

       
    }
}
