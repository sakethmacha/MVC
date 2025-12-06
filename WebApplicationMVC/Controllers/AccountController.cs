
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authentication;
    using System.Security.Claims;
    namespace WebApplicationMVC.Controllers
    {
        public class AccountController : Controller
        {
            [HttpGet]
            public IActionResult Login()
            {
                return View();
            }

            [HttpPost]
            public IActionResult Login(string username, string password)
            {
                if (username == "saketh" && password == "123")
                {
                    // 1. Create claims
                    var claims = new List<Claim>
                    {
                         new Claim(ClaimTypes.Name, username)
                    };

                    // 2. Create identity
                    var identity = new ClaimsIdentity(claims, "Cookies"); //CookieAuthenticationDefaults.AuthenticationScheme);

                    // 3. Create principal (user)
                    var principal = new ClaimsPrincipal(identity);

                    // 4. Sign in (this creates the cookie!)
                    //await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                    HttpContext.SignInAsync("Cookies", principal);
                    return RedirectToAction("SecretPage", "Home");
                }

                ViewBag.Error = "Invalid login";
                return View();
            }
            public IActionResult Logout()
            {
                HttpContext.SignOutAsync();
                return RedirectToAction("Login");
            }
        }
    }


