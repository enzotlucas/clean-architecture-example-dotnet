namespace Example.CleanArchitecture.Application.Queries.GetSales
{
    public class GetSalesQueryHandler : IRequestHandler<GetSalesQuery, IEnumerable<SaleViewModel>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<GetSalesQueryHandler> _logger;

        public GetSalesQueryHandler(IUnitOfWork unitOfWork,
                                    IMapper mapper,
                                    ILogger<GetSalesQueryHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IEnumerable<SaleViewModel>> Handle(GetSalesQuery request, CancellationToken cancellationToken)
        {
            if (request is null || request.Rows is null || request.Rows < 1 || request.Page is null || request.Page < 1)
                throw new BusinessException("The number of page and row need to be at least one");

            var sales = await _unitOfWork.Sales.GetSalesAsync(request.Page, request.Rows);

            _logger.LogInformation("Sales was queried", sales);

            return _mapper.Map<IEnumerable<SaleViewModel>>(sales);
        }
    }
}
