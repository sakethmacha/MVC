using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WebApplicationMVC.Interfaces.Interfaces;
using WebApplicationMVC.ViewModels.ViewModels;  // your viewmodel namespace

public class DataCheckFilter : IActionFilter
{
    private readonly IEmployeeValidationService EmployeeValidationService;

    public DataCheckFilter(IEmployeeValidationService validationService)
    {
        EmployeeValidationService = validationService;
    }

    public void OnActionExecuting(ActionExecutingContext context)
    {
        Console.WriteLine("DATA CHECK FILTER HIT!");

        // STEP 1: Detect any ViewModel passed into the action
        var model = context.ActionArguments
                           .FirstOrDefault(arg => arg.Value is EmployeeViewModel)
                           .Value as EmployeeViewModel;

        if (model == null)
            return;  // No ViewModel found → nothing to validate

        // STEP 2: Validate Email using service
        if (EmployeeValidationService.EmailExists(model.Email!) || EmployeeValidationService.PhoneExists(model.Phone!))
        {
            context.Result = new ViewResult
            {
                ViewName = "DataAlreadyExists"
            };
        }
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        // Optional: can log or modify result after action runs
    }
}
