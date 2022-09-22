namespace Example.CleanArchitecture.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<ProductService> _logger;

        public ProductService(IUnitOfWork unitOfWork, 
                              ILogger<ProductService> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<bool> DeleteProductAndItSales(Product product)
        {
            try
            {
                return await TryDeleteProductAndItSales(product);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message, product);
                throw new InfrastructureException("Error on deleting a product and it sales", ex);
            }
        }

        private async Task<bool> TryDeleteProductAndItSales(Product product)
        {
            _logger.LogInformation("Deleting sales from product", product);

            await _unitOfWork.BeginTransactionAsync();

            bool response = await DeleteProductsAndSales(product);

            await _unitOfWork.CommitAsync();

            return response;
        }

        private async Task<bool> DeleteProductsAndSales(Product product)
        {
            await _unitOfWork.Sales.DeleteSalesFromProduct(product);

            await _unitOfWork.Products.DeleteAsync(product);

            return await _unitOfWork.SaveChangesAsync();
        }
    }
}
