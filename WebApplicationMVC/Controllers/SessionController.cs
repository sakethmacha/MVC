using Microsoft.AspNetCore.Mvc; 
namespace WebApplicationMVC.Controllers
{
    public class SessionController:Controller
    {
        public IActionResult Signin() => View();

        [HttpPost]
        public IActionResult Signin(string username, string password)
        {
            if (username == "saketh" && password == "123")
            {
                HttpContext.Session.SetString("Username", username);
                return RedirectToAction("SecretPage", "Home");
            }

            ViewBag.Error = "Invalid Signin";
            return View();
        }

        public IActionResult Signout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Signin");
        }
        public IActionResult SecurePage()
        {
            if (HttpContext.Session.GetString("Username") == null)
            {
                return RedirectToAction("Signout", "Session");
            }

            return View();
        }
    }
}
