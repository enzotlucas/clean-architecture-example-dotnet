namespace Example.CleanArchitecture.Application.Commands.DeleteProduct
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductService _service;
        private readonly ILogger<DeleteProductCommandHandler> _logger;

        public DeleteProductCommandHandler(IUnitOfWork unitOfWork, 
                                           IProductService service,
                                           ILogger<DeleteProductCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _service = service;
            _logger = logger;
        }

        public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _unitOfWork.Products.GetByIdAsync(request.Id);

            if (!product.IsValid)
                throw new ProductNotFoundException();

            var deleted = await _service.DeleteProductAndItSales(product);

            if (!deleted)
                throw new InfrastructureException("Product was unable to delete");

            _logger.LogInformation("Product deleted", product);

            return Unit.Value;
        }
    }
}
