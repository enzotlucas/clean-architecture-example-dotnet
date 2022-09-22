namespace Example.CleanArchitecture.Core.Repositories
{
    public interface ISalesRepository : IRepository<Sale>
    {
        Task DeleteSalesFromProduct(Product product);
    }
}
