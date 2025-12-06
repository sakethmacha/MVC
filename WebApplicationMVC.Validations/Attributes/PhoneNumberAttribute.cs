using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace WebApplicationMVC.Validations.Attributes
{
    public class PhoneNumberAttribute : ValidationAttribute, IClientModelValidator
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
                return ValidationResult.Success;

            var phone = value.ToString();

            // Exactly 10 digits
            if (phone.Length != 10 || !phone.All(char.IsDigit))
            {
                var errorMessage = ErrorMessage ?? "Phone number must be exactly 10 digits.";
                return new ValidationResult(errorMessage);
            }

            // Starts with 6, 7, 8, or 9 (Indian mobile numbers)
            if (phone[0] < '6')
            {
                var errorMessage = ErrorMessage ?? "Phone number must start with 6, 7, 8, or 9.";
                return new ValidationResult(errorMessage);
            }

            return ValidationResult.Success;
        }

        public void AddValidation(ClientModelValidationContext context)
        {
            context.Attributes.Add("data-val", "true");
            context.Attributes.Add("data-val-phonenumber",
                ErrorMessage ?? "Invalid phone number.");
        }
    }
}
