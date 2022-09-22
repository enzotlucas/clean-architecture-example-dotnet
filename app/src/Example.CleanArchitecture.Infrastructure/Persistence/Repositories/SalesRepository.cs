namespace Example.CleanArchitecture.Infrastructure.Persistence.Repositories
{
    public sealed class SalesRepository : ISalesRepository
    {
        private readonly ApplicationContext _context;

        public SalesRepository(ApplicationContext context) => _context = context;

        public Task DeleteSalesFromProduct(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
