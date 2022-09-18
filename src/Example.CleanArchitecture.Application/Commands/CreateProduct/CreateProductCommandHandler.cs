namespace Example.CleanArchitecture.Application.Commands.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, ProductViewModel>
    {
        private readonly IUnitOfWork _uow;
        private readonly ILogger<CreateProductCommandHandler> _logger;
        private readonly IMapper _mapper;

        public CreateProductCommandHandler(IUnitOfWork uow, 
                                           ILogger<CreateProductCommandHandler> logger,
                                           IMapper mapper)
        {
            _uow = uow;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<ProductViewModel> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Product creation atempt", request);

            var product = _mapper.Map<Product>(request);

            if (await _uow.Products.ExistsAsync(product))
                throw new ProductExistsException();

            await _uow.Products.CreateAsync(product);

            if (!await _uow.SaveChangesAsync())
                throw new InfrastructureException("Unable to create product.");

            _logger.LogInformation($"Product created, product id: {product.Id}", product);

            return _mapper.Map<ProductViewModel>(product);
        }
    }
}
