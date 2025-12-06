using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace WebApplicationMVC.Validations.Attributes
{
    public class PasswordAttribute : ValidationAttribute, IClientModelValidator
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
                return ValidationResult.Success;

            var password = value.ToString();

            // Must be more than 8 characters
            if (password.Length <= 8)
            {
                var errorMessage = ErrorMessage ?? "Password must be more than 8 characters.";
                return new ValidationResult(errorMessage);
            }

            // Must contain at least one special character
            if (!password.Any(c => !char.IsLetterOrDigit(c)))
            {
                var errorMessage = ErrorMessage ?? "Password must contain at least one special character.";
                return new ValidationResult(errorMessage);
            }

            return ValidationResult.Success;
        }

        public void AddValidation(ClientModelValidationContext context)
        {
            context.Attributes.Add("data-val", "true");
            context.Attributes.Add("data-val-password",
                ErrorMessage ?? "Invalid password format.");
        }
    }
}
