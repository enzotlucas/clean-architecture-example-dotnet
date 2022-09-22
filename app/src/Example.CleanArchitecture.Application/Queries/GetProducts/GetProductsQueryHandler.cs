namespace Example.CleanArchitecture.Application.Queries.GetProducts
{
    public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, IEnumerable<ProductViewModel>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<GetProductsQueryHandler> _logger;

        public GetProductsQueryHandler(IUnitOfWork unitOfWork, 
                                  IMapper mapper,
                                  ILogger<GetProductsQueryHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IEnumerable<ProductViewModel>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            if (request is null || request.Rows is null || request.Rows < 1 || request.Page is null || request.Page < 1)
                throw new BusinessException("The number of page and row need to be at least one");

            var products = await _unitOfWork.Products.GetAllAsync(request.Page.Value, request.Rows.Value);

            _logger.LogInformation("Products was queried", products);

            return _mapper.Map<IEnumerable<ProductViewModel>>(products);
        }
    }
}
