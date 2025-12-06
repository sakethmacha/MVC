
using System.ComponentModel.DataAnnotations;
using WebApplicationMVC.Validations.Attributes;

namespace WebApplicationMVC.Models.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [NoNumbers(ErrorMessage = "Name cannot contain digits")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [NoNumbers(ErrorMessage = "Name cannot contain digits")]
        public string? City { get; set; }
    }
}
