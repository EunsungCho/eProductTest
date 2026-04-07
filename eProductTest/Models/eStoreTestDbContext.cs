using Microsoft.EntityFrameworkCore;

namespace eProductTest.Models
{
    public class eStoreTestDbContext: DbContext
    {
        public eStoreTestDbContext(DbContextOptions<eStoreTestDbContext> options): base(options)
        {
            
        }

        public DbSet<Product> Products => Set<Product>();
    }
}
