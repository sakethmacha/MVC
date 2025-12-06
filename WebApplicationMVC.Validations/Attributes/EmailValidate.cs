using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace WebApplicationMVC.Validations.Attributes
{
    public class EmailValidate : ValidationAttribute, IClientModelValidator
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
                return ValidationResult.Success;

            var email = value.ToString();

            // Must contain @
            if (!email.Contains("@"))
                return new ValidationResult(ErrorMessage ?? "Invalid email format.");

            int atIndex = email.IndexOf('@');

            // Username must exist before @
            if (atIndex == 0)
                return new ValidationResult(ErrorMessage ?? "Invalid email format. Username missing.");

            // Must end with .com
            if (!email.EndsWith(".com"))
                return new ValidationResult(ErrorMessage ?? "Email must end with .com");

            // Extract domain between @ and .com
            string domain = email.Substring(atIndex + 1, email.Length - atIndex - 5);

            // Must have domain name
            if (string.IsNullOrWhiteSpace(domain))
                return new ValidationResult(ErrorMessage ?? "Invalid domain name.");

            // Must not start with dot => @.com invalid
            if (domain.StartsWith("."))
                return new ValidationResult(ErrorMessage ?? "Invalid email domain.");

            return ValidationResult.Success;
        }

        public void AddValidation(ClientModelValidationContext context)
        {
            context.Attributes.Add("data-val", "true");
            context.Attributes.Add("data-val-emailvalidate",
                ErrorMessage ?? "Invalid email format.");
        }
    }
}
