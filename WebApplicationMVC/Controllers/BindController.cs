using Microsoft.AspNetCore.Mvc;
using WebApplicationMVC.Models.Models;

namespace WebApplicationMVC.Controllers
{
    public class BindController : Controller
    {

        [HttpGet("Bind/ShowRoute/{id}")]
        public IActionResult ShowRoute([FromRoute] int id)
        {
            return Content($"[FromRoute] The ID received is: {id}");
        }

        public IActionResult ShowQuery(
            [FromQuery] string name,
            [FromQuery] string password)
        {
            return Content($"[FromQuery] Name={name}, Password={password}");
        }

        public IActionResult EnterBody([FromBody] Details details)
        {
            return Content($"[FromBody] Name={details.Name}, Password={details.Password}");
        }
    }
}