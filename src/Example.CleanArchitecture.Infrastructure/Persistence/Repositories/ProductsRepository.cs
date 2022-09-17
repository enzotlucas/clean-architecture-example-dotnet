namespace Example.CleanArchitecture.Infrastructure.Persistence.Repositories
{
    public sealed class ProductsRepository : IProductsRepository
    {
        public Task<Product> CreateAsync(Product product)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistsAsync(string name, decimal price, decimal cost)
        {
            throw new NotImplementedException();
        }
    }
}
