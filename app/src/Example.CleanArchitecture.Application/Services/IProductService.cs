namespace Example.CleanArchitecture.Application.Services
{
    public interface IProductService
    {
        Task<bool> DeleteProductAndItSales(Product product);
    }
}
