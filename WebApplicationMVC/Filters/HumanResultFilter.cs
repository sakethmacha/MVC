using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApplicationMVC.Filters
{
    public class HumanResultFilter : IResultFilter
    {
        public void OnResultExecuting(ResultExecutingContext context)
        {
            var request = context.HttpContext.Request;

            // If user already clicked Yes
            if (request.Query.ContainsKey("human"))
            {
                return; // allow page to display normally
            }

            // Otherwise show human check view
            context.Result = new ViewResult
            {
                ViewName = "HumanCheck"
            };
        }

        public void OnResultExecuted(ResultExecutedContext context)
        {
        }
    }
}
