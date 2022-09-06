namespace Exemplo.CRUD.Application.Commands.CreateProduct
{
    public class CreateProductHandler : IRequestHandler<CreateProduct, ProductViewModel>
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateProductHandler> _logger;

        public CreateProductHandler(IProductRepository repository,
                                    IMapper mapper,
                                    ILogger<CreateProductHandler> logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger; 
        }

        public async Task<ProductViewModel> Handle(CreateProduct request, CancellationToken cancellationToken)
        {
            var product = request.ToEntity();

            if(!product.Valid)
                throw new BusinessException("Invalid Product");

            var response = await _repository.Create(product);

            if (!await _repository.UnitOfWork.Commit())
                throw new InfrastructureException("Product creation failed");

            _logger.LogInformation($"Product {response.Id} created.");

            return _mapper.Map<ProductViewModel>(response);
        }
    }
}
