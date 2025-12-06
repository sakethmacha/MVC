using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace WebApplicationMVC.Validations.Attributes
{
    public class NoNumbersAttribute : ValidationAttribute, IClientModelValidator
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
                return ValidationResult.Success;

            var stringValue = value.ToString();

            foreach (char c in stringValue)
            {
                if (char.IsDigit(c))
                {
                    var errorMessage = string.IsNullOrWhiteSpace(ErrorMessage)
                        ? "Numbers are not allowed in this field."
                        : ErrorMessage;

                    return new ValidationResult(errorMessage);
                }
            }

            return ValidationResult.Success;
        }

        public void AddValidation(ClientModelValidationContext context)
        {
            context.Attributes.Add("data-val", "true");
            context.Attributes.Add("data-val-nonumbers", ErrorMessage ?? "Numbers are not allowed in this field.");
        }
    }
}
