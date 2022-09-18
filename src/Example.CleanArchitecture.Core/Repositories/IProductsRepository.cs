namespace Example.CleanArchitecture.Core.Repositories
{
    public interface IProductsRepository : IRepository<Product>
    {
        Task<bool> ExistsAsync(Product product);
        Task<Product> CreateAsync(Product product);
        Task<Product> GetById(Guid guid);
    }
}
