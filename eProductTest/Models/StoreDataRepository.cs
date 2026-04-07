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
    }
}
