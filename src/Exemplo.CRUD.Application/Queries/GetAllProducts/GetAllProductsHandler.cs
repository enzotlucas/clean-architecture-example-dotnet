namespace Exemplo.CRUD.Application.Queries.GetAllProducts
{
    public class GetAllProductsHandler : IRequestHandler<GetAllProducts, IEnumerable<ProductViewModel>>
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;

        public GetAllProductsHandler(IProductRepository repository,
                                    IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductViewModel>> Handle(GetAllProducts request, CancellationToken cancellationToken)
        {
            var products = await _repository.GetAll();

            return _mapper.Map<IEnumerable<ProductViewModel>>(products);
        }
    }
}
