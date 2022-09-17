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

        public Task<ProductViewModel> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
