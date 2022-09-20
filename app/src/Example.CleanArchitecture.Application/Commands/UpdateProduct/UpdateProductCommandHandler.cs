namespace Example.CleanArchitecture.Application.Commands.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger _logger;

        public UpdateProductCommandHandler(IUnitOfWork unitOfWork, 
                                           ILogger logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _unitOfWork.Products.GetByIdAsync(request.Id);

            if (!product.IsValid)
                throw new ProductNotFoundException();

            product.Update(request.Name, 
                           request.Quantity, 
                           request.Price, 
                           request.Cost, 
                           request.Enabled, 
                           request.Category);

            await _unitOfWork.Products.UpdateAsync(product);

            if (!await _unitOfWork.SaveChangesAsync())
                throw new InfrastructureException("Unable to save update for product");

            _logger.LogInformation("Product updated", product);

            return Unit.Value;
        }
    }
}
