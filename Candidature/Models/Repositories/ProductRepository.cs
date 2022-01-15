using Candidature.Data;

namespace Candidature.Models.Repositories
{
    public class ProductRepository : IStoreRepository<Product>
    {
        private readonly MyDbContext db;
      
        public ProductRepository(MyDbContext _db)
        {
            db = _db;
        }
        public void Add(Product t)
        {
            db.Product.Add(t);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            db.Remove(Find(id));
            db.SaveChanges();
        }

        public Product Find(int id)
        {
            Product product = GetAll().FirstOrDefault( p => p.Id == id);
            return product;
        }

        public IList<Product> GetAll()
        {
            return db.Product.ToList();
        }

        public void Update(Product t)
        {
            db.Product.Update(t);
            db.SaveChanges();
        }
    }
}
