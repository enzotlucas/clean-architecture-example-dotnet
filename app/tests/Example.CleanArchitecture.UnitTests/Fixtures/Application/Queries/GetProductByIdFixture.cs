namespace Example.CleanArchitecture.UnitTests.Fixtures.Queries
{
    public class GetProductByIdFixture
    {
        public GetProductByIdQueryHandler GenerateValidHandler(Product product, ProductViewModel productViewModel)
        {
            var uow = Substitute.For<IUnitOfWork>();
            uow.Products.GetByIdAsync(Arg.Any<Guid>()).Returns(product);


            var mapper = Substitute.For<IMapper>();
            mapper.Map<ProductViewModel>(Arg.Any<Product>()).Returns(productViewModel);

            return new GetProductByIdQueryHandler(uow, mapper);
        }

        public GetProductByIdQueryHandler GenerateInvalidHandler()
        {
            var uow = Substitute.For<IUnitOfWork>();
            uow.Products.GetByIdAsync(Arg.Any<Guid>()).Returns(new Product());

            var mapper = Substitute.For<IMapper>();

            return new GetProductByIdQueryHandler(uow, mapper);
        }
    }
}
