namespace eProductTest.Models
{
    public interface IDataRepository
    {
        IQueryable<Product> Products { get; }
    }
}
