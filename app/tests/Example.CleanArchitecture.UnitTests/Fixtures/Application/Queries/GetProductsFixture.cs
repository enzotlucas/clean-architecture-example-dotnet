namespace Example.CleanArchitecture.UnitTests.Fixtures.Application.Queries
{
    public class GetProductsFixture
    {
        public GetProductsQueryHandler GenerateValidHandler(IEnumerable<Product> products,
                                                            IEnumerable<ProductViewModel> productViewModels)
        {
            var uow = Substitute.For<IUnitOfWork>();
            uow.Products.GetAllAsync(Arg.Any<int>(), Arg.Any<int>()).Returns(products);

            var mapper = Substitute.For<IMapper>();
            mapper.Map<IEnumerable<ProductViewModel>>(Arg.Any<IEnumerable<Product>>()).Returns(productViewModels);

            var logger = Substitute.For<ILogger<GetProductsQueryHandler>>();

            return new GetProductsQueryHandler(uow, mapper, logger);
        }
    }
}
