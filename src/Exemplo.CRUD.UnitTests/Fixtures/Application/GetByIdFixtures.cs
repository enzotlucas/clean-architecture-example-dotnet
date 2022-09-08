namespace Exemplo.CRUD.UnitTests.Fixtures.Application
{
    public static class GetByIdFixtures
    {
        public static GetByIdHandler GenerateValidHandler(Product product, ProductViewModel productViewModel, GetById request)
        {
            var repository = Substitute.For<IProductRepository>();
            repository.GetById(request.Id).Returns(Task.FromResult(product));

            var mapper = Substitute.For<IMapper>();
            mapper.Map<ProductViewModel>(Arg.Any<Product>()).Returns(productViewModel);

            var logger = Substitute.For<ILogger<GetByIdHandler>>();

            return new GetByIdHandler(repository, mapper, logger);
        }

        public static GetByIdHandler GenerateInvalidHandler(GetById request, Product product)
        {
            var repository = Substitute.For<IProductRepository>();
            repository.GetById(request.Id).Returns(Task.FromResult(product));

            var mapper = Substitute.For<IMapper>();

            var logger = Substitute.For<ILogger<GetByIdHandler>>();

            return new GetByIdHandler(repository, mapper, logger);
        }
    }
}
