using System.ComponentModel.DataAnnotations;

namespace WebApplicationMVC.Enums
{
    public enum Department
    {
        [Display(Name = "Human Resources")]
        HR,

        [Display(Name = "Information Technology")]
        IT,

        Finance,
        Sales,
        Marketing
    }
}
