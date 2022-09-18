namespace Example.CleanArchitecture.Infrastructure.Persistence.Repositories
{
    public sealed class ProductsRepository : IProductsRepository
    {
        public Task<Product> CreateAsync(Product product)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistsAsync(Product product)
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetById(Guid guid)
        {
            throw new NotImplementedException();
        }
    }
}
