using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace WebApplicationMVC.Validations.Attributes
{
    public class PasswordAttribute : ValidationAttribute, IClientModelValidator
    {
        // Strong password:
        // - Min 8 characters
        // - At least 1 uppercase
        // - At least 1 lowercase
        // - At least 1 digit
        // - At least 1 special character
        private const string DefaultPattern =
            @"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[^A-Za-z0-9]).{8,}$";

        private readonly Regex _regex;

        public PasswordAttribute() : base("Password must contain uppercase, lowercase, number, special character, and be at least 8 characters.")
        {
            _regex = new Regex(DefaultPattern, RegexOptions.Compiled);
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null || string.IsNullOrWhiteSpace(value.ToString()))
                return ValidationResult.Success;

            var password = value.ToString();

            if (!_regex.IsMatch(password))
                return new ValidationResult(ErrorMessage);

            return ValidationResult.Success;
        }

        public void AddValidation(ClientModelValidationContext context)
        {
            context.Attributes["data-val"] = "true";
            context.Attributes["data-val-password"] = ErrorMessage;
            context.Attributes["data-val-password-pattern"] = DefaultPattern;
        }

    }
}
