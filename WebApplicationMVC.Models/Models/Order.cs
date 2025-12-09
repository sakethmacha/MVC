using System.ComponentModel.DataAnnotations;
using WebApplicationMVC.Validations.Attributes;

namespace WebApplicationMVC.Models.Models
{
    public class Order
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(150)]
        [Display(Name = "Customer Name")]
        [NoNumbers(ErrorMessage = "Customer name cannot contain numbers")]
        public string? CustomerName { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Foreign Key
        [Required]
        public int StatusId { get; set; }

        public OrderStatus? Status { get; set; }
    }

}
