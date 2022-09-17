namespace Example.CleanArchitecture.Core.Repositories
{
    public interface IProductsRepository : IRepository<Product>
    {
        Task<bool> ExistsAsync(string name, decimal price, decimal cost);
        Task<Product> CreateAsync(Product product);
    }
}
