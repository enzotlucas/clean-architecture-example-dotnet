namespace Exemplo.CRUD.Application.Commands.DeleteProduct
{
    public class DeleteProductHandler : IRequestHandler<DeleteProduct, bool>
    {
        private readonly IProductRepository _repository;
        private readonly ILogger<DeleteProductHandler> _logger;

        public DeleteProductHandler(IProductRepository repository,
                                    ILogger<DeleteProductHandler> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<bool> Handle(DeleteProduct request, CancellationToken cancellationToken)
        {
            var product = await _repository.GetById(request.Id);

            if (!product.Exists)
                throw new ProductNotFoundException(request.Id);

            await _repository.Delete(product);

            if (!await _repository.UnitOfWork.Commit())
                throw new InfrastructureException("Product deletion failed");

            _logger.LogInformation($"Product {request.Id} deleted.");

            return true;
        }
    }
}
