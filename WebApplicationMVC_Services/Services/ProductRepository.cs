using Microsoft.EntityFrameworkCore;
using WebApplicationMVC.Interfaces.Interfaces;
using WebApplicationMVC.Models.Models;
namespace WebApplicationMVC_Services.Services
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _db;

        public ProductRepository(ApplicationDbContext db)
        {
            _db = db;
            Console.WriteLine("Repository Created - Hash: " + GetHashCode());
            Console.WriteLine("DbContext Created - Hash: " + db.GetHashCode());
        }

        public void Add(Details product)
        {
            _db.Detailss.Add(product);    // Add to DbSet
            _db.SaveChanges();            // Commit to DB
        }
        public IEnumerable<Details> GetAll()
        {
            return _db.Detailss.ToList();
        }
        public Details? GetById(int id)   
        {
            return _db.Detailss.FirstOrDefault(x => x.DetailsId == id);
        }
    }
}
