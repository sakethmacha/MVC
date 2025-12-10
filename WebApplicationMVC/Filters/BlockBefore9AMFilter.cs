using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApplicationMVC.Filters
{
    public class BlockBefore9AMFilter : Attribute, IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            var now = DateTime.Now;
  
            // Code running BEFORE controller action
            if (now.Hour < 9)
            {
                context.Result = new ViewResult
                {
                    ViewName = "Blocked"
                };
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            // Not needed here
        }
    }
}
