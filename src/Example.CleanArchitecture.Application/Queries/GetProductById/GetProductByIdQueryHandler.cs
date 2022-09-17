namespace Example.CleanArchitecture.Application.Queries.GetProductById
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductViewModel>
    {
        private readonly IUnitOfWork _uow;
        private readonly ILogger<GetProductByIdQueryHandler> _logger;

        public GetProductByIdQueryHandler(IUnitOfWork uow,
                                          ILogger<GetProductByIdQueryHandler> logger)
        {
            _uow = uow;
            _logger = logger;
        }

        public Task<ProductViewModel> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
