using WebApplicationMVC.Validations.Attributes;
using System.ComponentModel.DataAnnotations;

namespace WebApplicationMVC.ViewModels.ViewModels
{
    public class EmployeeViewModel
    {
        public int EmployeeId { get; set; } 

        [Required(ErrorMessage = "First Name is required")]
        [StringLength(50, MinimumLength = 2)]
        [Display(Name = "First Name")]
        [NoNumbers(ErrorMessage = "First name cannot contain numbers")]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        [StringLength(50)]
        [Display(Name = "Last Name")]
        [NoNumbers(ErrorMessage = "Last name cannot contain numbers")]
        public string? LastName { get; set; }

        [Required, MaxLength(100)]
        [EmailValidate(ErrorMessage = "Invalid email format.")]
        public string? Email { get; set; }

        [PhoneNumber(ErrorMessage = "Phone number must be 10 digits and start with 6, 7, 8, or 9.")]
        [Display(Name = "Phone Number")]
        public string? Phone { get; set; }

        [Required]
        [Range(18, 65)]
        public int Age { get; set; }

        [Required, DataType(DataType.Date)]
        [Display(Name = "Date of Birth")]
        public DateTime DOB { get; set; }

        [Required, StringLength(150)]
        [Display(Name = "Home Address")]
        public string? Address { get; set; }

        [Required, DataType(DataType.Password)]
        [Password(ErrorMessage = "Invalid password format.")]
        public string? Password { get; set; }

        [Required, DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        [Display(Name = "Confirm Password")]
        public string? ConfirmPassword { get; set; }

        [Range(typeof(decimal), "0", "9999999")]
        [DataType(DataType.Currency)]
        public decimal Salary { get; set; }

        [Required]
        public string? Gender { get; set; }

        [Required]
        public bool IsMarried { get; set; }

        [Required]
        public string? Department { get; set; }
    }
}
