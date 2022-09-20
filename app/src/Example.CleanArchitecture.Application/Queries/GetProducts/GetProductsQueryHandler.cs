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
            var products = await _unitOfWork.Products.GetAllAsync(request.Page, request.Rows);

            _logger.LogInformation("Products was queried", products);

            return _mapper.Map<IEnumerable<ProductViewModel>>(products);
        }
    }
}
