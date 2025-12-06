using WebApplicationMVC.Models.Models;

namespace WebApplicationMVC.ViewModels
{
    public class CreateViewModel
    {
        public Details? InsertedItem { get; set; }
        public IEnumerable<Details>? AllRecords { get; set; }
    }
}
