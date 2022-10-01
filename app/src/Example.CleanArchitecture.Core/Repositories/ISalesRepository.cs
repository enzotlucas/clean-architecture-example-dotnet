namespace Example.CleanArchitecture.Core.Repositories
{
    public interface ISalesRepository : IRepository<Sale>
    {
        Task DeleteSalesFromProductAsync(Product product);
        Task<IEnumerable<Sale>> GetSalesAsync(int? page, int? rows);
    }
}
