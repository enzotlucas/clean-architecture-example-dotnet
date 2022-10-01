namespace Example.CleanArchitecture.Application.Queries.GetSales
{
    public class GetSalesQueryHandler : IRequestHandler<GetSalesQuery, IEnumerable<SaleViewModel>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetSalesQueryHandler(IUnitOfWork unitOfWork,
                                    IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SaleViewModel>> Handle(GetSalesQuery request, CancellationToken cancellationToken)
        {
            var sales = await _unitOfWork.Sales.GetSalesAsync(request.Page, request.Rows);

            return _mapper.Map<IEnumerable<SaleViewModel>>(sales);
        }
    }
}
