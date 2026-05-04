namespace eProductTest.Models
{
    public class StoreDataRepository: IDataRepository
    {
        private readonly eStoreTestDbContext _context;
        public StoreDataRepository(eStoreTestDbContext context)
        {
            _context = context;
        }

        public IQueryable<Product> Products => _context.Products;

        public void CreateProduct(Product p)
        {
            _context.Add(p);
            _context.SaveChanges();
        }

        public void DeleteProduct(Product p)
        {
            _context.Remove(p);
            _context.SaveChanges();
        }

        public void SaveProduct(Product p)
        {
            _context.SaveChanges();
        }
    }
}
