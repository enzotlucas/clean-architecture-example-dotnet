namespace Example.CleanArchitecture.Infrastructure.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext _context;
        private IDbContextTransaction _transaction;

        public IProductsRepository Products { get; }
        public ISalesRepository Sales { get; }

        public UnitOfWork(ApplicationContext context,
                          IProductsRepository products,
                          ISalesRepository sales)
        {
            _context = context;
            Products = products;
            Sales = sales;
        }

        public async Task<bool> SaveChangesAsync() =>
                await _context.SaveChangesAsync() > 0;

        public async Task BeginTransactionAsync() =>
                _transaction = await _context.Database.BeginTransactionAsync();

        public async Task CommitAsync()
        {
            try
            {
                await _transaction.CommitAsync();
            }
            catch (Exception)
            {
                await _transaction.RollbackAsync();
                throw;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
                _context.Dispose();
        }
    }
}
