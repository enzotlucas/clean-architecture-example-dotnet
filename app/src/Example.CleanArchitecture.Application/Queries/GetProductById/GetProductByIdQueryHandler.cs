namespace Example.CleanArchitecture.Application.Queries.GetProductById
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductViewModel>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public GetProductByIdQueryHandler(IUnitOfWork uow, 
                                          IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<ProductViewModel> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await _uow.Products.GetById(request.Id);

            if (!product.IsValid)
                throw new ProductNotFoundException();

            return _mapper.Map<ProductViewModel>(product);
        }
    }
}
