using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace WebApplicationMVC.Validations.Attributes
{
    public class EmailValidate : ValidationAttribute, IClientModelValidator
    {
        private const string Pattern = @"^[A-Za-z0-9]+@[A-Za-z]+\.com$";


        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null)
                return ValidationResult.Success;

            var email = value.ToString();
            
            if (!Regex.IsMatch(email!, Pattern))
                return new ValidationResult(ErrorMessage ?? "Invalid email format.");

            return ValidationResult.Success;
        }

        public void AddValidation(ClientModelValidationContext context)
        {
            context.Attributes.Add("data-val", "true");
            context.Attributes.Add("data-val-regex", ErrorMessage ?? "Invalid email format.");
            context.Attributes.Add("data-val-regex-pattern", Pattern);
        }
    }
}
