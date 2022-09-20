namespace Example.CleanArchitecture.Core.Repositories
{
    public interface IProductsRepository : IRepository<Product>
    {
        Task<bool> ExistsAsync(Product product);
        Task<Product> CreateAsync(Product product);
        Task<Product> GetByIdAsync(Guid guid);
        Task<IEnumerable<Product>> GetAllAsync(int page, int rows);
    }
}
