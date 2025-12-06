

using System.ComponentModel.DataAnnotations;
using WebApplicationMVC.Validations.Attributes;

namespace WebApplicationMVC.Models.Models
{
    public class Details
    {
        public int DetailsId { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [NoNumbers(ErrorMessage = "Name cannot contain digits")]
        public string? Name { get; set; }

        [Password(ErrorMessage = "Password must be more than 8 characters and contain at least one special character.")]
        public string? Password { get; set; }
    }
}
