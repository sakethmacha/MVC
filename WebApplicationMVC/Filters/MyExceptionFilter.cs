using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApplicationMVC.Filters
{
    public class MyExceptionFilter : Attribute, IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            // Get actual error message
            string errorMessage = context.Exception.Message;

            // Return friendly output
            context.Result = new ContentResult
            {
                Content = $"❌ Exception Filter Caught Error:\n{errorMessage}",
                StatusCode = 500
            };

            context.ExceptionHandled = true;
        }
    }
}
