namespace Exemplo.CRUD.Infrastructure.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductContext _context;

        public ProductRepository(ProductContext context) => _context = context;

        IUnitOfWork IProductRepository.UnitOfWork => _context;

        public async Task<Product> Create(Product product)
        {
            return await Task.Run(() =>
            {
                _context.Db.Add(product);

                return product;
            });
        }

        public async Task Delete(Product product) => 
                await Task.Run(() => { _context.Db.Remove(product); });

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await Task.Run(() =>
            {
                return _context.Db;
            });
        }

        public async Task<Product> GetById(Guid id)
        {
            return await Task.Run(() =>
            {
                var product = _context.Db.Where(p => p.Id.Equals(id)).FirstOrDefault();

                return product ?? new Product();
            });
        }
    }
}
