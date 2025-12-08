using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplicationMVC.Validations.Attributes;

namespace WebApplicationMVC.Models.Models
{
    public class OrderStatus
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Name")]
        [NoNumbers(ErrorMessage = "Name cannot contain numbers")]
        public string? Name { get; set; }

        [Required]
        [MaxLength(200)]
        [NoNumbers(ErrorMessage = "Description cannot contain numbers")]
        public string? Description { get; set; }
    }

}
