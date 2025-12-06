using System.ComponentModel.DataAnnotations;
using WebApplicationMVC.Validations.Attributes;

namespace WebApplicationMVC.ViewModels
{
    public class ProductViewModel
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, MinimumLength = 2)]
        [Display(Name = "Name")]
        [NoNumbers(ErrorMessage = "Name cannot contain numbers")]
        public string? Name { get; set; }
        [Required]
        [Range(18, 65, ErrorMessage = "Age must be between 18 and 65")]
        public int Age { get; set; }
        [Required]
        [MaxLength(100)]
        [EmailValidate(ErrorMessage = "Invalid email. Must end with .com and contain a valid domain.")]
        public string? Email { get; set; }
    }
}
