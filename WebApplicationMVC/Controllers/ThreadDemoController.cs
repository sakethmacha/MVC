using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplicationMVC.Models.Models;

namespace WebApplicationMVC.Controllers
{
    public class ThreadDemoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ThreadDemoController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult SyncTest()
        {
            Thread.Sleep(5000); // simulate long DB/query work (blocks thread)

            var products = _context.Students
                                   .OrderBy(p => p.Name)
                                   .ToList(); // BLOCKING EF CORE CALL

            return Content($"SYNC Completed at: {DateTime.Now:T}");
        }

        public async Task<IActionResult> AsyncTest()
        {
            await Task.Delay(5000); // simulate long DB work (non-blocking)

            var products = await _context.Students
                                         .OrderBy(p => p.Name)
                                         .ToListAsync(); // NON-BLOCKING EF CORE CALL

            return Content($"ASYNC Completed at: {DateTime.Now:T}");
        }
    }
}

