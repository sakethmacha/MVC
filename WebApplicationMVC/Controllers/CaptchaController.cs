using Microsoft.AspNetCore.Mvc;

namespace WebApplicationMVC.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    namespace WebApplicationMVC.Controllers
    {
        public class CaptchaController : Controller
        {
            public IActionResult Index()
            {
                Random rnd = new Random();
                int code = rnd.Next(1000, 9999);

                // Store in SESSION — NEVER LOST
                HttpContext.Session.SetString("CaptchaCode", code.ToString());

                // Show to user using ViewBag (safe)
                ViewBag.CaptchaCode = code;

                return View();
            }

            [HttpPost]
            public IActionResult Verify(string userInput)
            {
                // Get captcha from session
                var original = HttpContext.Session.GetString("CaptchaCode");

                if (original == null)
                {
                    TempData["Error"] = "Captcha expired! Try again.";
                    return RedirectToAction("Index");
                }

                // Correct captcha?
                if (userInput == original)
                {
                    TempData["IsHuman"] = true;

                    // Optional clear
                    HttpContext.Session.Remove("CaptchaCode");

                    return RedirectToAction("Create", "Employee");
                }

                TempData["Error"] = "Wrong captcha!";
                return RedirectToAction("Index");
            }
        }
    }



}
