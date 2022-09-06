namespace Exemplo.CRUD.Application.Queries.GetById
{
    public class GetByIdHandler : IRequestHandler<GetById, ProductViewModel>
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<GetByIdHandler> _logger;

        public GetByIdHandler(IProductRepository repository, 
                              IMapper mapper,
                              ILogger<GetByIdHandler> logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ProductViewModel> Handle(GetById request, CancellationToken cancellationToken)
        {
            var product = await _repository.GetById(request.Id);

            if (!product.Exists)
                throw new ProductNotFoundException(request.Id);

            _logger.LogInformation($"Get product {request.Id}");

            return _mapper.Map<ProductViewModel>(product);
        }
    }
}
