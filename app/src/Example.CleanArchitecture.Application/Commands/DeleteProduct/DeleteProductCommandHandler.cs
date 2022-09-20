namespace Example.CleanArchitecture.Application.Commands.DeleteProduct
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<DeleteProductCommandHandler> _logger;

        public DeleteProductCommandHandler(IUnitOfWork unitOfWork, 
                                           ILogger<DeleteProductCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _unitOfWork.Products.GetByIdAsync(request.Id);

            if (!product.IsValid)
                throw new ProductNotFoundException();

            await _unitOfWork.Products.DeleteAsync(product);

            if (!await _unitOfWork.SaveChangesAsync())
                throw new InfrastructureException("Product was unable to delete");

            _logger.LogInformation("Product deleted", product);

            return Unit.Value;
        }
    }
}
