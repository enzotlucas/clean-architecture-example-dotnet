namespace Example.CleanArchitecture.Core.Repositories
{
    public interface ISalesRepository : IRepository<Sale>
    {
        Task DeleteSalesFromProductAsync(Product product);
        Task<IEnumerable<Sale>> GetAllAsync(int? page, int? rows);
    }
}
