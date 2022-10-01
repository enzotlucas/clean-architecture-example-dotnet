using Dapper;
using Microsoft.Data.SqlClient;

namespace Example.CleanArchitecture.Infrastructure.Persistence.Repositories
{
    public sealed class SalesRepository : ISalesRepository
    {
        private readonly ApplicationContext _context;

        public SalesRepository(ApplicationContext context) => _context = context;

        public async Task DeleteSalesFromProductAsync(Product product)
        {
            if (product is null || product.SaleItems is null || !product.SaleItems.Any())
                return;

            await Task.Run(() =>
            {
                _context.SaleItems.RemoveRange(product.SaleItems);

                _context.Sales.Remove(product);
            });
        }

        public async Task<IEnumerable<Sale>> GetSalesAsync(int? page, int? rows)
        {
            var query =
                @"SELECT *
                  FROM Sale
                  ORDER BY Id
                  OFFSET (@page -1 ) * @rows ROWS FETCH NEXT @rows ROWS ONLY";

            var dbConnection = new SqlConnection(_context.Database.GetDbConnection().ConnectionString);

            return await dbConnection.QueryAsync<Sale>(
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
