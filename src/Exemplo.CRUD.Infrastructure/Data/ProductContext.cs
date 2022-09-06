namespace Exemplo.CRUD.Infrastructure.Data
{
    public class ProductContext : IUnitOfWork
    {
        public readonly List<Product> Db;

        public ProductContext() => Db = new List<Product>();

        public async Task<bool> Commit()
        {
            return await Task.Run(() =>
            {
                return true;
            });
        }
    }
}
