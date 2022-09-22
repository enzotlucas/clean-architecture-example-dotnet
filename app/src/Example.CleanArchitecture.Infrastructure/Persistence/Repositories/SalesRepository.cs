namespace Example.CleanArchitecture.Infrastructure.Persistence.Repositories
{
    public sealed class SalesRepository : ISalesRepository
    {
        private readonly ApplicationContext _context;

        public SalesRepository(ApplicationContext context) => _context = context;

        public async Task DeleteSalesFromProduct(Product product)
        {
            if (product is null || product.SaleItems is null || product.SaleItems.Any())
                return;

            await Task.Run(() =>
            {
                _context.SaleItems.RemoveRange(product.SaleItems);

                _context.Sales.Remove(product);
            });
        }
    }
}
