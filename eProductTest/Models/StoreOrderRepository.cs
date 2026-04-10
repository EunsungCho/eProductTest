using Microsoft.EntityFrameworkCore;

namespace eProductTest.Models
{
    public class StoreOrderRepository: IOrderRepository
    {
        private eStoreTestDbContext _dbContext;
        public StoreOrderRepository(eStoreTestDbContext ctx)
        {
            _dbContext = ctx;
        }

        public IQueryable<Order> Orders => _dbContext.Orders
            .Include(o => o.Lines)
            .ThenInclude(l => l.Product);

        public void SaveOrder(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
