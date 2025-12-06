using WebApplicationMVC.Models.Models;

namespace WebApplicationMVC.Interfaces.Interfaces
{
    public interface IProductRepository
    {
        void Add(Details product);
        IEnumerable<Details>? GetAll();
        Details? GetById(int id);
    }
}
