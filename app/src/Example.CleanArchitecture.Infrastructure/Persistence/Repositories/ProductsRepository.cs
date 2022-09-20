using Dapper;
using Microsoft.Data.SqlClient;

namespace Example.CleanArchitecture.Infrastructure.Persistence.Repositories
{
    public sealed class ProductsRepository : IProductsRepository
    {
        private readonly ApplicationContext _context;

        public ProductsRepository(ApplicationContext context) 
            => _context = context;

        public async Task<Product> CreateAsync(Product product)
        {
            await _context.Products.AddAsync(product);

            return product;
        }

        public async Task<bool> ExistsAsync(Product product) => 
            await _context.Products.AnyAsync(p => p.Name.Equals(product.Name) &&
                                                  p.Category.Equals(product.Category));

        public async Task<Product> GetByIdAsync(Guid id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id.Equals(id));

            return product ?? new Product();
        }

        public async Task<IEnumerable<Product>> GetAllAsync(int page, int rows)
        {
            var query =
                @"SELECT *
                  FROM PRODUCTS
                  ORDER BY NAME
                  OFFSET (@page -1 ) * @rows ROWS FETCH NEXT @rows ROWS ONLY";

            var dbConnection = new SqlConnection(_context.Database.GetDbConnection().ConnectionString);

            return await dbConnection.QueryAsync<Product>(
               query,
               new
               {
                   page,
                   rows
               }
            );
        }
    }
}
